using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Asset.SmartLists.RequestProvider;
using MarketoApiLibrary.Common.Configuration;
using MarketoApiLibrary.Common.Http.Oauth;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace MarketoApiLibrary.Tests.Asset.SmartLists.RequestProvider
{
    public class GetSmartListsRequestProviderTests
    {
        private readonly Mock<IConfigurationProvider> _configurationProvider;
        private readonly Mock<IAuthenticationTokenProvider> _authenticationTokenProvider;

        public GetSmartListsRequestProviderTests()
        {
            this._configurationProvider = new Mock<IConfigurationProvider>();
            this._authenticationTokenProvider = new Mock<IAuthenticationTokenProvider>();
        }

        [Fact]
        public void GetRelativeUrl_IfAllDataProvided_ShouldReturnUrl()
        {
            // arrange
            var request = new GetSmartListsRequest();
            var expectedUrl = $"/{Constants.UrlSegments.Asset}/{Constants.UrlSegments.Version}/{Constants.UrlSegments.SmartLists}";
            var requestProvider = this.GetInstance();

            // act
            var result = requestProvider.GetRelativeUrl(request);

            // assert
            Assert.NotNull(result);
            Assert.Equal(expectedUrl, result);
        }

        [Fact]
        public void GetHttpMethod_IfCalled_ShouldReturnHttpGet()
        {
            // arrange
            var requestProvider = this.GetInstance();

            // act
            var result = requestProvider.GetHttpMethod();

            // assert
            Assert.Equal(HttpMethod.Get, result);
        }

        [Fact]
        public void GetQueryString_ShouldReturnValidParameters()
        {
            // arrange
            var request = new GetSmartListsRequest();
            var requestProvider = this.GetInstance();

            // act
            var result = requestProvider.GetQueryString(request);

            // assert
            Assert.NotNull(result);
            Assert.True(result.ContainsKey(Constants.QueryParameters.Asset.SmartList.Keys.Offset));
            Assert.True(result.ContainsKey(Constants.QueryParameters.Asset.SmartList.Keys.MaxReturn));
            Assert.True(result.ContainsKey(Constants.QueryParameters.Asset.SmartList.Keys.EarliestUpdatedAt));
            Assert.True(result.ContainsKey(Constants.QueryParameters.Asset.SmartList.Keys.LatestUpdatedAt));
            //Assert.Equal(party.PartyId, result[AddressId]);
        }

        [Fact]
        public void GetQueryString_ShouldSetFolder_IfFolderCountGreaterThanZero()
        {
            // arrange
            var request = new GetSmartListsRequest();
            var folder = new Dictionary<string, dynamic>();
            folder.Add("id", "folderType");
            request.Folder = folder;
            var requestProvider = this.GetInstance();

            // act
            var result = requestProvider.GetQueryString(request);

            // assert
            Assert.NotNull(result);
            Assert.True(result.ContainsKey(Constants.QueryParameters.Asset.SmartList.Keys.Offset));
            Assert.True(result.ContainsKey(Constants.QueryParameters.Asset.SmartList.Keys.MaxReturn));
            Assert.True(result.ContainsKey(Constants.QueryParameters.Asset.SmartList.Keys.EarliestUpdatedAt));
            Assert.True(result.ContainsKey(Constants.QueryParameters.Asset.SmartList.Keys.LatestUpdatedAt));
            Assert.True(result.ContainsKey(Constants.QueryParameters.Asset.SmartList.Keys.Folder));
            Assert.Equal(JsonConvert.SerializeObject(request.Folder), result[Constants.QueryParameters.Asset.SmartList.Keys.Folder]);
        }

        private GetSmartListsRequestProviderTest GetInstance()
        {
            return new GetSmartListsRequestProviderTest(this._configurationProvider.Object, this._authenticationTokenProvider.Object);
        }

        private class GetSmartListsRequestProviderTest : GetSmartListsRequestProvider
        {
            public GetSmartListsRequestProviderTest(IConfigurationProvider configuration,
                IAuthenticationTokenProvider authenticationTokenProvider) :
                base(configuration, authenticationTokenProvider)
            {
            }

            public new string GetRelativeUrl(GetSmartListsRequest request)
            {
                return base.GetRelativeUrl(request);
            }

            public new HttpMethod GetHttpMethod()
            {
                return base.GetHttpMethod();
            }

            public new Dictionary<string, string> GetQueryString(GetSmartListsRequest request)
            {
                return base.GetQueryString(request);
            }

        }
    }
}
