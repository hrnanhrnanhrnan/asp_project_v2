using Candyshop.Models;
using Candyshop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Candyshop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CampaignController : Controller
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly ICandyRepository _candyRepository;
        private readonly IDiscountRepository _discountRepository;

        public CampaignController(ICampaignRepository campaignRepository, ICandyRepository candyRepository, IDiscountRepository discountRepository)
        {
            _campaignRepository = campaignRepository;
            _candyRepository = candyRepository;
            _discountRepository = discountRepository;
        }

        public IActionResult Index()
        {
            try
            {
                return View(_campaignRepository.Campaigns);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                return View(new CampaignEditViewModel()
                {
                    Campaign = _campaignRepository.GetById(id),
                    Candies = _candyRepository.GetAllCandy
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult Create()
        {
            return View(new Campaign());
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var campaign = _campaignRepository.GetById(id);
                if (campaign != null)
                    _campaignRepository.DeleteCampaign(campaign);
                return Redirect("../Index");
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult SubmitCreateCampaign(Campaign campaign)
        {
            try
            {
                _campaignRepository.CreateCampaign(campaign);
                return RedirectToAction("Edit", new { id = campaign.ID });
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult SubmitEditCampaign(CampaignEditViewModel view)
        {
            try
            {
                _campaignRepository.UpdateCampaign(view.Campaign);
                return Redirect("Index");
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult CreateDiscount(int campaign, int candy)
        {
            try
            {
                return View(new Discount()
                {
                    CampaignId = campaign,
                    CandyId = candy,
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult AddDiscount(Discount discount)
        {
            try
            {
                _discountRepository.CreateDiscount(discount);
                return RedirectToAction("Edit", new { id = discount.CampaignId });
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult EditDiscount(int id)
        {
            try
            {
                var discount = _discountRepository.GetById(id);
                return View(discount);
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult SubmitEditDiscount(Discount discount)
        {
            try
            {
                _discountRepository.UpdateDiscount(discount);
                return RedirectToAction("Edit", new { id = discount.CampaignId });
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult RemoveDiscount(int id)
        {
            try
            {
                var discount = _discountRepository.GetById(id);
                int campaignID = discount.CampaignId;
                _discountRepository.DeleteDiscount(discount);

                return RedirectToAction("Edit", new { id = discount.CampaignId });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
