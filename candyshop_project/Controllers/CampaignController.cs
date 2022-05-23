using Candyshop.Models;
using Candyshop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Candyshop.Controllers
{
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
            return View(_campaignRepository.Campaigns);
        }

        public IActionResult Edit(int id)
        {
            return View(new CampaignEditViewModel()
            {
                Campaign = _campaignRepository.GetById(id),
                Candies = _candyRepository.GetAllCandy
            });
        }

        public IActionResult Create()
        {
            return View(new Campaign());
        }

        public IActionResult Delete(int id)
        {
            var campaign = _campaignRepository.GetById(id);
            if(campaign != null)
                _campaignRepository.DeleteCampaign(campaign);
            return Redirect("../Index");
        }

        public IActionResult SubmitCreateCampaign(Campaign campaign)
        {
            _campaignRepository.CreateCampaign(campaign);
            return RedirectToAction("Edit", new { id = campaign.ID });
        }

        public IActionResult SubmitEditCampaign(CampaignEditViewModel view)
        {
            _campaignRepository.UpdateCampaign(view.Campaign);
            return Redirect("Index");
        }

        public IActionResult CreateDiscount(int campaign, int candy)
        {
            return View(new Discount()
            {
                CampaignId = campaign,
                CandyId = candy,
            });
        }

        public IActionResult AddDiscount(Discount discount)
        {
            _discountRepository.CreateDiscount(discount);
            return RedirectToAction("Edit", new { id = discount.CampaignId });
        }

        public IActionResult EditDiscount(int id)
        {
            var discount = _discountRepository.GetById(id);
            return View(discount);
        }

        public IActionResult SubmitEditDiscount(Discount discount)
        {
            _discountRepository.UpdateDiscount(discount);
            return RedirectToAction("Edit", new { id = discount.CampaignId });
        }

        public IActionResult RemoveDiscount(int id)
        {
            var discount = _discountRepository.GetById(id);
            int campaignID = discount.CampaignId;
            _discountRepository.DeleteDiscount(discount);

            return RedirectToAction("Edit", new { id = discount.CampaignId });
        }
    }
}
