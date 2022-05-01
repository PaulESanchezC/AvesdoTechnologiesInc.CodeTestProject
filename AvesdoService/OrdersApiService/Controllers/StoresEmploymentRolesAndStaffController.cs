using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.StaffModels;
using Services.Repository.StaffRepository;
using Services.TinyRepository.EmploymentRoleTinyRepository;
using Services.TinyRepository.StoresTinyRepository;

namespace ApiOrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresEmploymentRolesAndStaffController : ControllerBase
    {
        private readonly IEmploymentRolesRepository _employmentRolesRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IStoreRepository _storesRepository;
        public StoresEmploymentRolesAndStaffController(IEmploymentRolesRepository employmentRolesRepository, IStaffRepository staffRepository, IStoreRepository storesRepository)
        {
            _employmentRolesRepository = employmentRolesRepository;
            _staffRepository = staffRepository;
            _storesRepository = storesRepository;
        }

        [HttpGet("GetAllStoresInformation")]
        public async Task<IActionResult> GetAllStoresInformation(CancellationToken cancellationToken)
        {
            var request = await _storesRepository.GetAllByAsync(null, null, false, cancellationToken,
                include => include.Tax, include => include.StaffList);
            return StatusCode(request.StatusCode, request);
        }

        [HttpGet("GetSingleStoreAllStaff/{storeId}")]
        public async Task<IActionResult> GetSingleStoreAllStaff(string storeId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(storeId))
            {
                ModelState.AddModelError("storeId", "The storeId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _staffRepository.GetAllByAsync( store => store.StoreId == storeId,null,cancellationToken,
            include => include.EmploymentRole);
            return StatusCode(request.StatusCode, request);
        }

        [HttpGet("GetSingleStaffInformation/{staffId}")]
        public async Task<IActionResult> GetSingleStaffInformation(string staffId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(staffId))
            {
                ModelState.AddModelError("staffId", "The staffId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _staffRepository.GetSingleByAsync(staff => staff.StaffId == staffId, cancellationToken,
            include => include.EmploymentRole);
            return StatusCode(request.StatusCode, request);
        }

        [HttpGet("GetAllEmploymentRoles")]
        public async Task<IActionResult> GetAllEmploymentRoles(CancellationToken cancellationToken)
        {
            var request = await _employmentRolesRepository.GetAllByAsync(null, null, false, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [Authorize]
        [HttpPost("RegisterNewStaffMember")]
        public async Task<IActionResult> RegisterNewStaffMember([FromBody] StaffCreateDto staffToCreate,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _staffRepository.CreateAsync(staffToCreate, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [Authorize]
        [HttpPut("UpdateStaffProfileInformation")]
        public async Task<IActionResult> UpdateStaffProfileInformation([FromBody] StaffUpdateDto staffUpdateDto,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _staffRepository.UpdateAsync(staffUpdateDto, cancellationToken);
            return StatusCode(request.StatusCode,request);
        }

        [Authorize]
        [HttpDelete("DeleteStaffProfile/{staffId}")]
        public async Task<IActionResult> DeleteStaffProfile(string staffId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(staffId))
            {
                ModelState.AddModelError("staffId", "The staffId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _staffRepository.DeleteAsync(staffId, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }
    }
}
