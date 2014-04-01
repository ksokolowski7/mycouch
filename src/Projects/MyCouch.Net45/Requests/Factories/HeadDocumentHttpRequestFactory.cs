﻿using System.Net.Http;
using EnsureThat;
using MyCouch.Net;

namespace MyCouch.Requests.Factories
{
    public class HeadDocumentHttpRequestFactory : DocumentHttpRequestFactoryBase
    {
        public HeadDocumentHttpRequestFactory(IConnection connection) : base(connection) { }

        public virtual HttpRequest Create(HeadDocumentRequest request)
        {
            Ensure.That(request, "request").IsNotNull();

            var httpRequest = CreateFor<HeadDocumentRequest>(HttpMethod.Head, GenerateRequestUrl(request.Id, request.Rev));

            httpRequest.SetIfMatch(request.Rev);

            return httpRequest;
        }
    }
}