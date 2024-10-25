using Dedsi.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace TemplateDrivenDesignNet;

[ApiController]
[Area(TemplateDrivenDesignNetDomainOptions.ApplicationName)]
[Route("api/TemplateDrivenDesignNet/[controller]/[action]")]
public abstract class TemplateDrivenDesignNetController : DedsiControllerBase;