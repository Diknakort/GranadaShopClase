var builder = DistributedApplication.CreateBuilder(args);


builder.AddProject<Projects.GranadaShopClase_API_Identity>("granadashopclase-api-identity");

builder.Build().Run();
