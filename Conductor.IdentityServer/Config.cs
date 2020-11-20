using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Conductor.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope> { new ApiScope("Conductor.SystemAPIService", "Conductor.TrackingAPIService") };

        //public static IEnumerable<IdentityResource> IdentityResources =>
        //    new List<IdentityResource>
        //    {
        //        new IdentityResources.OpenId(),
        //        new IdentityResources.Profile()
        //    };

        /// <summary>
        /// 需要保护的Api资源
        /// 4.x版本新增后续Scopes的配置
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            List<ApiResource> resources = new List<ApiResource>();
            //ApiResource第一个参数是ServiceName，第二个参数是描述
            resources.Add(new ApiResource("Conductor.SystemAPIService", "GoodsService服务需要保护哦") { Scopes = { "Conductor.SystemAPIService" } });
            return resources;
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[] {
             //secretapi:标识名称，Secret Api：显示名称，可以自定义
             new ApiResource("Conductor.SystemAPIService","Conductor.TrackingAPIService")
         };
        }
        public static IEnumerable<Client> Clients => new List<Client>
        {
             new Client
            {
                ClientId = "client",
                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                // secret for authentication
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                // scopes that client has access to
                AllowedScopes = { "Conductor.SystemAPIService" }
            },
            //new Client
            //{
            //    ClientId="client",
            //    AllowedGrantTypes= GrantTypes.ClientCredentials,

            //    ClientSecrets={ new Secret("secret".Sha256())},
            //    AllowedScopes={ "api1", "api2" }
            //},
            new Client
            {
                ClientId="clientPwd",
                AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,

                ClientSecrets={ new Secret("secret".Sha256())},
                AllowedScopes={ "Conductor.SystemAPIService", "Conductor.TrackingAPIService" }
            },
            //new Client()
            //    {
            //        //客户端Id
            //         ClientId="apiClientImpl",
            //         ClientName="ApiClient for Implicit",
            //         //客户端授权类型，Implicit:隐藏模式
            //         AllowedGrantTypes=GrantTypes.Implicit,
            //         //允许登录后重定向的地址列表，可以有多个
            //        RedirectUris = {"https://localhost:6011/auth.html" },
            //         //允许访问的资源
            //         AllowedScopes={
            //            "api1"
            //        },
            //         //允许将token通过浏览器传递
            //         AllowAccessTokensViaBrowser=true
            //    }

        };

        public static List<TestUser> GetTestUsers() => new List<TestUser> {
            new TestUser(){
                SubjectId="1",
                Username="edwin",
                Password="123456"
            },
            new TestUser(){
                SubjectId="2",
                Username="jack",
                Password="123456"
            },
             new TestUser()
            {
                //用户名
                 Username="apiUser",
                 //密码
                 Password="apiUserPassword",
                 //用户Id
                 SubjectId="0"
            }
        };


    }
}
