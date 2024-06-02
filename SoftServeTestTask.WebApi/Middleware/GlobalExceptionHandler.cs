using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SoftServeTestTask.WebApi.Middleware
{
    internal sealed class GlobalExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var traceId = Guid.NewGuid();

            var problemDetails = new ProblemDetails();

            switch (exception)
            {
                case ValidationException validationException:
                    {
                        WriteInfoAboutErrorToProblemDetails(
                            problemDetails,
                            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                            "Validation error",
                            StatusCodes.Status400BadRequest,
                            context.Request.Path,
                            $"One or more validation errors has occured, traceID: {traceId}");

                        context.Response.StatusCode = StatusCodes.Status400BadRequest;

                        if (validationException.Errors is not null)
                        {
                            problemDetails.Extensions["errors"] = validationException.Errors;
                        }

                        break;
                    }
                case ArgumentNullException argumentNullException:
                    {
                        WriteInfoAboutErrorToProblemDetails(
                            problemDetails,
                            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                            "Argument null exception.",
                            StatusCodes.Status400BadRequest,
                            context.Request.Path,
                            $"Argument null exception has occured, traceID:{traceId}");

                        context.Response.StatusCode = StatusCodes.Status400BadRequest;                      

                        problemDetails.Extensions["errors"] = argumentNullException.Message;

                        break;
                    }
                case ArgumentException argumentException:
                    {
                        WriteInfoAboutErrorToProblemDetails(
                           problemDetails,
                           "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                           "Argument exception.",
                           StatusCodes.Status400BadRequest,
                           context.Request.Path,
                           $"Argument exception has occured, traceID:{traceId}");

                        context.Response.StatusCode = StatusCodes.Status400BadRequest;

                        problemDetails.Extensions["errors"] = argumentException.Message;

                        break;
                    }
                case KeyNotFoundException keyNotFoundException:
                    {
                        WriteInfoAboutErrorToProblemDetails(
                            problemDetails,
                            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                            "Key not found error.",
                            StatusCodes.Status404NotFound,
                            context.Request.Path,
                            $"Key not found exception has occured, traceID:{traceId}");

                        context.Response.StatusCode = StatusCodes.Status404NotFound;

                        problemDetails.Extensions["errors"] = keyNotFoundException.Message;

                        break;
                    }

                default:
                    {
                        WriteInfoAboutErrorToProblemDetails(
                            problemDetails,
                            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                            "Internal Server Error",
                            StatusCodes.Status500InternalServerError,
                            context.Request.Path,
                            $"Internal server error occured, traceID: {traceId}");

                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                        break;
                    }
            }

            await context.Response.WriteAsJsonAsync(problemDetails);
        }

        private static void WriteInfoAboutErrorToProblemDetails(ProblemDetails problemDetails, string errorType, string errorTitle, int errorStatusCode, string errorInstance, string errorDetail)
        {
            problemDetails.Type = errorType;
            problemDetails.Title = errorTitle;
            problemDetails.Status = errorStatusCode;
            problemDetails.Instance = errorInstance;
            problemDetails.Detail = errorDetail;
        }
    }
}
