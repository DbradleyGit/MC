using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MC.Data;

namespace MC.Controllers
{
	public class tmodelsController : Controller
	{
		#region DECLARATIONS

		private D010MCSEntities db = new D010MCSEntities();

		#endregion

		#region Task<ActionResult>

		public async Task<ActionResult> Index()
		{
			// GET: tmodels
			var tmodel = db.tmodel.Include(t => t.tmake).Include(t => t.tyear);
			return View(await tmodel.ToListAsync());
		}

		public async Task<ActionResult> Details(int? id)
		{
			// GET: tmodels/Details/5
			if ( id == null )
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			tmodel tmodel = await db.tmodel.FindAsync(id);
			if ( tmodel == null )
			{
				return HttpNotFound();
			}
			return View(tmodel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "id,year_id,make_id,model_na")] tmodel tmodel)
		{
			// POST: tmodels/Create
			// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
			// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
			if ( ModelState.IsValid )
			{
				db.tmodel.Add(tmodel);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			ViewBag.make_id = new SelectList(db.tmake, "id", "make_na", tmodel.make_id);
			ViewBag.year_id = new SelectList(db.tyear, "yr", "yr", tmodel.year_id);
			return View(tmodel);
		}

		public async Task<ActionResult> Edit(int? id)
		{
			// GET: tmodels/Edit/5
			if ( id == null )
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			tmodel tmodel = await db.tmodel.FindAsync(id);
			if ( tmodel == null )
			{
				return HttpNotFound();
			}
			ViewBag.make_id = new SelectList(db.tmake, "id", "make_na", tmodel.make_id);
			ViewBag.year_id = new SelectList(db.tyear, "yr", "yr", tmodel.year_id);
			return View(tmodel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "id,year_id,make_id,model_na")] tmodel tmodel)
		{
			// POST: tmodels/Edit/5
			// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
			// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
			if ( ModelState.IsValid )
			{
				db.Entry(tmodel).State = EntityState.Modified;
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			ViewBag.make_id = new SelectList(db.tmake, "id", "make_na", tmodel.make_id);
			ViewBag.year_id = new SelectList(db.tyear, "yr", "yr", tmodel.year_id);
			return View(tmodel);
		}

		public async Task<ActionResult> Delete(int? id)
		{
			// GET: tmodels/Delete/5
			if ( id == null )
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			tmodel tmodel = await db.tmodel.FindAsync(id);
			if ( tmodel == null )
			{
				return HttpNotFound();
			}
			return View(tmodel);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			// POST: tmodels/Delete/5
			tmodel tmodel = await db.tmodel.FindAsync(id);
			db.tmodel.Remove(tmodel);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		public ActionResult Cycles()
		{
			var tmodel = db.tmodel.Include(t => t.tmake).Include(t => t.tyear).Include(t => t.Years);
			ViewBag.make_id = new SelectList(db.tmake, "id", "make_na");
			ViewBag.year_id = new SelectList(db.tyear, "yr", "yr");
			return View();
		}

		#endregion

		#region ActionResult

		public ActionResult Create()
		{
			// GET: tmodels/Create		
			ViewBag.make_id = new SelectList(db.tmake, "id", "make_na");
			ViewBag.year_id = new SelectList(db.tyear, "yr", "yr");
			return View();
		}

		#endregion

		#region Dispose

		protected override void Dispose(bool disposing)
		{
			if ( disposing )
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		#endregion
	}
}
