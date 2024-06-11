using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TravelerCoreProject.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {
        //veritabanından id'ye uygun yorumları getirmek için:
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        Context context = new Context();

        //Comment id ye göre Db den getirme:
        //public IViewComponentResult Invoke(int id)
        //{
        //    var values=commentManager.TGetDestinationById(id);
        //    return View(values);
        //}

        //DEstination İD ve user İd ye göre veri getirme:
        public IViewComponentResult Invoke(int id)
        {
            //yorum sayısını tutmak için:
            ViewBag.commentCount=context.Comments.Where(x=>x.DestinationID==id).Count();
            var values = commentManager.TGetListCommentWithDestinationAndUser(id);
            return View(values);
        }
    }
}
