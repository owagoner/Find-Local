using FindLocal.Models;
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
    }
}