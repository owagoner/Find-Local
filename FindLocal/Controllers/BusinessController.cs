﻿using FindLocal.Models;
using FindLocal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindLocal.Controllers
{
    public class BusinessController : Controller
    {
        private BusinessService bs = new BusinessService();
        private AddressService ads = new AddressService();
        private CommentService cs = new CommentService();
        private MediaService ms = new MediaService();

        public ActionResult Index(int id)
        {
            BusinessViewModel vm = new BusinessViewModel();
                        
            Business b = bs.getBusinessById(id);
            b.comments = cs.getCommentsByBusinessId(id);
            b.media = ms.getMediaByBusinessId(id).FirstOrDefault();
            b.address = ads.getAddressByBusinessId(id).FirstOrDefault();           
            vm.business = b;

            vm.relatedBusiness = bs.getBusinessesByType(b.businessTypeId);
            foreach(var bb in vm.relatedBusiness) {
                bb.media = new Media();
                bb.media.featureImage = ms.getFeaturedByBusinessId((int)bb.id);
            }

            return View(vm);
        }
        public ActionResult List(int id) {
            ViewBag.businessType = getBusinessType(id);
            List<Business> b = new List<Business>();
            b = bs.getBusinessesByType(id);
            foreach (var business in b) {
                business.media = new Media();
                business.media.featureImage = ms.getFeaturedByBusinessId((int)business.id);
            }            
            return View(b);
        }

        private string getBusinessType(int id) {
            if (id == 1)
            {
                return "Barbers";
            }
            else if (id == 2)
            {
                return "Salons";
            }
            else if (id == 3)
            {
                return "Mechanics";
            }
            else if (id == 4)
            {
                return "Oil Change";
            }
            else {
                return "Not Found";
            }
        }
    }
}