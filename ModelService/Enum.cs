﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ModelService
{
    public enum StatusCode
    {
        VpnConnected,
        VpnNotConnected,
        InternetConnected,
        InternetNotConnected,
        Sent,
        Error,
        Success,
        Failure,
        Passed,
        MethodNotImplemented,


        Continue = 100,
        SwitchingProtocols = 101,
        Processing = 102,
        EarlyHints = 103,
        OK = 200,
        Created = 201,
        Accepted = 202,
        NonAuthoritativeInformation = 203,
        NoContent = 204,
        ResetContent = 205,
        PartialContent = 206,
        MultiStatus = 207,
        AlreadyReported = 208,
        IMUsed = 226,
        Ambiguous = 300,
        MultipleChoices = 300,
        Moved = 301,
        MovedPermanently = 301,
        Found = 302,
        Redirect = 302,
        RedirectMethod = 303,
        SeeOther = 303,
        NotModified = 304,
        UseProxy = 305,
        Unused = 306,
        RedirectKeepVerb = 307,
        TemporaryRedirect = 307,
        PermanentRedirect = 308,
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        NotAcceptable = 406,
        ProxyAuthenticationRequired = 407,
        RequestTimeout = 408,
        Conflict = 409,
        Gone = 410,
        LengthRequired = 411,
        PreconditionFailed = 412,
        RequestEntityTooLarge = 413,
        RequestUriTooLong = 414,
        UnsupportedMediaType = 415,
        RequestedRangeNotSatisfiable = 416,
        ExpectationFailed = 417,
        MisdirectedRequest = 421,
        UnprocessableEntity = 422,
        Locked = 423,
        FailedDependency = 424,
        UpgradeRequired = 426,
        PreconditionRequired = 428,
        TooManyRequests = 429,
        RequestHeaderFieldsTooLarge = 431,
        UnavailableForLegalReasons = 451,
        InternalServerError = 500,
        NotImplemented = 501,
        BadGateway = 502,
        ServiceUnavailable = 503,
        GatewayTimeout = 504,
        HttpVersionNotSupported = 505,
        VariantAlsoNegotiates = 506,
        InsufficientStorage = 507,
        LoopDetected = 508,
        NotExtended = 510,
        NetworkAuthenticationRequired = 511
    }

    public enum SourceAppCd
    {
        ATEST_SND_A_COR,
        ATEST_PRD_A_COR
    }
}
