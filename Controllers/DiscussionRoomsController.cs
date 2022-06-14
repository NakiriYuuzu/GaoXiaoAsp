using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GaoXiaoAsp.Models;

namespace GaoXiaoAsp.Controllers
{
    [Authorize]
    public class DiscussionRoomsController : Controller
    {
        private LibraryEntity db = new LibraryEntity();

        // GET: DiscussionRooms
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.DiscussionRooms.ToList());
        }
        
        [AllowAnonymous]
        public ActionResult RoomType(int? id)
        {
            IEnumerable<DiscussionRoom> discussionRooms = null;

            if (id == 0)
            {
                discussionRooms = db.DiscussionRooms.Where(x => x.MaxSize == 8);
            }
                
            if (id == 1)
            {
                discussionRooms = db.DiscussionRooms.Where(x => x.MaxSize == 15 && x.RoomType.Equals("討論室"));
            }

            if (id == 2)
            {
                discussionRooms = db.DiscussionRooms.Where(x => x.RoomType.Equals("團體視聽室"));
            }
                
            if (id == 3)
            {
                discussionRooms = db.DiscussionRooms.Where(x => x.MaxSize == 2);
            }
            
            return View(discussionRooms);
        }

        // GET: DiscussionRooms/Details/5
        [Authorize (Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DiscussionRoom discussionRoom = db.DiscussionRooms.Find(id);
            
            if (discussionRoom == null)
            {
                return HttpNotFound();
            }
            
            return View(discussionRoom);
        }
        
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiscussionRooms/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "Rid,RoomNumber,Floors,RoomType,RoomAccess,MinSize,MaxSize")] DiscussionRoom discussionRoom)
        {
            if (ModelState.IsValid)
            {
                db.DiscussionRooms.Add(discussionRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(discussionRoom);
        }

        // GET: DiscussionRooms/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscussionRoom discussionRoom = db.DiscussionRooms.Find(id);
            if (discussionRoom == null)
            {
                return HttpNotFound();
            }
            return View(discussionRoom);
        }

        // POST: DiscussionRooms/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Rid,RoomNumber,Floors,RoomType,RoomAccess,MinSize,MaxSize")] DiscussionRoom discussionRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discussionRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discussionRoom);
        }

        // GET: DiscussionRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscussionRoom discussionRoom = db.DiscussionRooms.Find(id);
            if (discussionRoom == null)
            {
                return HttpNotFound();
            }
            return View(discussionRoom);
        }

        // POST: DiscussionRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiscussionRoom discussionRoom = db.DiscussionRooms.Find(id);
            db.DiscussionRooms.Remove(discussionRoom);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
