var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.M_V_C>("m-v-c");

builder.Build().Run();
