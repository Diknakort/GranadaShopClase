using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// 1. Agregar el servidor PostgreSQL (usará la imagen oficial de Docker)
var postgres = builder.AddPostgres("postgres")
                      .WithImage("postgres:latest")// Imagen oficial
                      .WithPgAdmin(pgAdmin => pgAdmin.WithHostPort(5050))
                      //.WithEnvironment("POSTGRES_PASSWORD", "htVepm3{tDKv.p4H4wP9cF") // Contraseña del superusuario
                      .WithLifetime(ContainerLifetime.Persistent);     // Mantiene datos entre reinicios
                                                                       
postgres.AddDatabase("identityauthdb");

builder.AddProject<Projects.GranadaShopClase_API_Identity>("granadashopclase-api-identity")
       .WaitFor(postgres)
       .WithReference(postgres);

builder.Build().Run();
