using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            string room = "R" + id;
            TempData["room"] = id;

            var lendingStatus = db.LendingStatus.Where(x => x.DiscussionRoom1.RoomNumber == room).ToList();

            return View(lendingStatus);
            // var lendingStatus = db.LendingStatus.Include(l => l.DiscussionRoom1).Include(l => l.Librarian).Include(l => l.User);
            // return View(lendingStatus.ToList());
        }

        // GET: LendingStatus/Create
        public ActionResult Create(int? id)
        {
            TempData["createRoom"] = id;
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
        public ActionResult Create([Bind(Include = "LendingID,UserID,DiscussionRoom,StartTime,EndTime,NumberOfPeople,Lid,IsExpired")] LendingStatu lendingStatu, int? id)
        {
            if (ModelState.IsValid)
            {
                var userID = db.Users.FirstOrDefault(x => x.Name == User.Identity.Name);
                var roomID = db.DiscussionRooms.FirstOrDefault(x => x.RoomNumber == "R" + id);

                lendingStatu.LendingID = db.LendingStatus.Count() + 1;
                lendingStatu.UserID = userID.Uid;
                lendingStatu.DiscussionRoom = roomID.Rid;
                Console.WriteLine(roomID.Rid);
                lendingStatu.IsExpired = 0;
                db.LendingStatus.Add(lendingStatu);
                db.SaveChanges();
                TempData["createData"] = "success";
                return Redirect("/LendingStatus/Index/" + id);
            }

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
