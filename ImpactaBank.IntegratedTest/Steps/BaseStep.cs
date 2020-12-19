using BoDi;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace ImpactaBank.IntegratedTest.Steps
{
    public class BaseStep
    {
        protected IRestClient _restClient;
        protected IRestRequest _restRequest;
        protected IRestResponse _restResponse;
        protected IObjectContainer _objectContainer;
        protected Uri _baseHost = new Uri("https://localhost:5001/");
        protected string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFkbUBlbWFpbC5jb20iLCJuYW1laWQiOiIxIiwicm9sZSI6IkEiLCJuYmYiOjE2MDgzOTg4OTAsImV4cCI6MTYwODQwNjA5MCwiaWF0IjoxNjA4Mzk4ODkwfQ.dHPOVQHhu44CGSa5pxbTRuxpZcer3sI-0vPZdoDeTcA";

        public BaseStep(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Setup()
        {
            _restClient = new RestClient();
            _restRequest = new RestRequest();
            _restResponse = new RestResponse();
            _objectContainer.RegisterInstanceAs(_restClient);
            _objectContainer.RegisterInstanceAs(_restRequest);
            _objectContainer.RegisterInstanceAs(_restResponse);
            _restClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }

    }
}
