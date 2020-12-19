using BoDi;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using RestSharp;
using System.Net;
using Xunit;
using ImpactaBank.API.Model.Request;

namespace ImpactaBank.IntegratedTest.Steps
{
    [Binding]
    public sealed class Step : BaseStep
    {
        private AccountRequest _accountRequest;

        public Step(IObjectContainer objectContainer) : base(objectContainer)
        {
            _accountRequest = new AccountRequest();
        }

        #region HttpClient

        [Given(@"the host is '(.*)'")]
        public void GivenTheHostIs(string url) => this._baseHost = new Uri(url);

        [Given(@"the endpoint is '(.*)'")]
        public void GivenTheEndPointIs(string endpoint) => _restRequest.Resource = endpoint;

        [Given(@"the http method is '(.*)'")]
        public void GivenTheHttpMethodIs(string httpMethod)
        {
            switch (httpMethod)
            {
                case "GET":
                    _restRequest.Method = Method.GET;
                    break;
                case "POST":
                    _restRequest.Method = Method.POST;
                    break;
                case "PUT":
                    _restRequest.Method = Method.PUT;
                    break;
                case "DELETE":
                    _restRequest.Method = Method.DELETE;
                    break;            }    
        }

        [Given(@"the token is '(.*)'")]
        public void GivenTheTokenIs(string token) => this._token = token;

        #endregion

        #region When

        [When(@"execute the request")]
        public void WhenExecuteTheRequest()
        {
            if (_restRequest.Method == Method.GET)
                this.Request(new { });
            else 
            {
                switch (_restRequest.Resource.ToLower())
                {
                    case "account/insert":
                    case "account/update":
                        this.Request(_accountRequest);
                        break;
                }
            }                
        }

        #endregion

        #region Then

        [Then(@"the response should be (.*)")]
        public void ResponseShouldBe(HttpStatusCode responseStatusCode) => Assert.Equal(responseStatusCode, _restResponse.StatusCode);

        #endregion

        #region Request

        private void Request<T>(T requestBody)
        {
            _restClient.BaseUrl = this._baseHost;
            _restRequest.AddHeader("Authorization", "Bearer " + this._token);

            if (_restRequest.Method!= Method.GET)
            {
                _restRequest.AddHeader("Content-Type", "application/json");
                _restRequest.AddJsonBody(requestBody);                
            }

            _restResponse = _restClient.Execute(_restRequest);
        }

        #endregion

        #region User

        [Given(@"the e-mail is '(.*)'")]
        public void GivenTheEmailIs(string email) => _restRequest.AddParameter("email", email);

        [Given(@"the password is '(.*)'")]
        public void GivenThePasswordIs(string password) => _restRequest.AddParameter("password", password);

        #endregion

        #region Account

        [Given(@"the CustomerId is (.*)")]
        public void GivenTheCustomerIdIs(int customerId) => _accountRequest.CustomerId = customerId;

        [Given(@"the Situation is '(.*)'")]
        public void GivenTheSituationIs(string situation) => _accountRequest.Situation = situation;

        [Given(@"the AccountId is (.*)")]
        public void GivenTheAccountIdIs(int id) => _restRequest.AddParameter("id",id, ParameterType.QueryString);

        #endregion
    }
}
