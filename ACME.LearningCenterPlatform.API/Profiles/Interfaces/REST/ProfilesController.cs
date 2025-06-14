using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Services;
using ACME.LearningCenterPlatform.API.Profiles.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.LearningCenterPlatform.API.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProfilesController(
    IProfileCommandService profileCommandService,
    IProfileQueryService profileQueryService) : ControllerBase
{
    [HttpGet("{profileId:int}")]
    public async Task<ActionResult> GetProfileById(int profileId)
    {
        var getProfileByIdQuery = new GetProfileByIdQuery(profileId);
        var profile = await profileQueryService.Handle(getProfileByIdQuery);
        if (profile == null) return NotFound();
        var profileResource = ProfileResourceFromEntity.ToResourceFromEntity(profile);
        return Ok(profileResource);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProfile(CreateProfileResource resource)
    {
        var createProfileCommand = CreateProfileCommandFromResource.ToCommandFromResource(resource);
        var profile = await profileCommandService.Handle(createProfileCommand);
        if (profile == null) return BadRequest();
        var profileResource = ProfileResourceFromEntity.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetProfileById), new { profileId = profile.Id }, profileResource);
    }
}