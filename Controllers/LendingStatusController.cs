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
    public class LendingStatusController : Controller
    {
        private LibraryEntity db = new LibraryEntity();

        // GET: LendingStatus
        public ActionResult Index(int? id)
        {
            var lendingStatus = db.LendingStatus.Include(l => l.DiscussionRoom1).Include(l => l.Librarian).Include(l => l.User);
            return View(lendingStatus.ToList());
        }

        // GET: LendingStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LendingStatu lendingStatu = db.LendingStatus.Find(id);
            if (lendingStatu == null)
            {
                return HttpNotFound();
            }
            return View(lendingStatu);
        }

        // GET: LendingStatus/Create
        public ActionResult Create()
        {
            ViewBag.DiscussionRoom = new SelectList(db.DiscussionRooms, "Rid", "RoomNumber");
            ViewBag.Lid = new SelectList(db.Librarians, "Lid", "Name");
            ViewBag.UserID = new SelectList(db.Users, "Uid", "Name");
            return View();
        }

        // POST: LendingStatus/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LendingID,UserID,DiscussionRoom,StartTime,EndTime,NumberOfPeople,Lid,IsExpired")] LendingStatu lendingStatu)
        {
            if (ModelState.IsValid)
            {
                db.LendingStatus.Add(lendingStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiscussionRoom = new SelectList(db.DiscussionRooms, "Rid", "RoomNumber", lendingStatu.DiscussionRoom);
            ViewBag.Lid = new SelectList(db.Librarians, "Lid", "Name", lendingStatu.Lid);
            ViewBag.UserID = new SelectList(db.Users, "Uid", "Name", lendingStatu.UserID);
            return View(lendingStatu);
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
