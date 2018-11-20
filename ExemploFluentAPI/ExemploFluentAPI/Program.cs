using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploFluentAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePrincipalLoginInformation login = new ServicePrincipalLoginInformation();
            login.ClientId = "ClientID";
            login.ClientSecret = "Client Secret";

            var tenant = "Tenant ID";

            AzureCredentials credentials = new AzureCredentials(login, tenant, AzureEnvironment.AzureGlobalCloud);
            var azure = Azure.Authenticate(credentials).WithSubscription("Subscription ID");

            var windowsVM = azure.VirtualMachines.Define("ExemploFluentCDS")
                .WithRegion(Region.BrazilSouth)
                .WithNewResourceGroup("ResourceVMTeste")
                .WithNewPrimaryNetwork("10.0.0.0/28")
                .WithPrimaryPrivateIpAddressDynamic()
                .WithNewPrimaryPublicIpAddress("exemplofluentcds")
                .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012R2Datacenter)
                .WithAdminUsername("administrador")
                .WithAdminPassword("Cds123456")
                .WithSize(VirtualMachineSizeTypes.BasicA1)
                .Create();

            var blob = azure.StorageAccounts.Define("minhaconta")
                .WithRegion(Region.BrazilSouth)
                .WithNewResourceGroup("ResourceBlob")
                .Create();

            var webApp = azure.WebApps.Define("meusitecds")
                .WithNewResourceGroup("ResurceSite")
                .WithNewAppServicePlan("AppServicePlanNovo")
                .WithRegion(Region.BrazilSouth)
                .WithPricingTier(AppServicePricingTier.SharedD1)
                .Create();

        }
    }
}
