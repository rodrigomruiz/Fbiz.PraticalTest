using AutoMapper;
using Fbiz.PraticalTest.Application.Interface;
using Fbiz.PraticalTest.Domain.Entities;
using Fbiz.PraticalTest.Store.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Fbiz.PraticalTest.Store.Controllers
{
    public class CommentsController : Controller
    {
        private readonly IProductAppService _productApp;
        private readonly ICommentAppService _commentApp;
        
        public CommentsController(IProductAppService productApp, ICommentAppService commentApp)
        {
            _productApp = productApp;
            _commentApp = commentApp;
        }
        
        // GET: Comments
        public ActionResult Index()
        {
            var commentViewModel = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewModel>>(_commentApp.GetAll());
            return View(commentViewModel);
        }

        // GET: Comments/Details/5
        public ActionResult Details(int id)
        {
            var comment = _commentApp.GetById(id);
            var commentViewModel = Mapper.Map<Comment, CommentViewModel>(comment);

            return View(commentViewModel);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(_productApp.GetAll(), "ProductId", "Name");
            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        public ActionResult Create(CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var commentDomain = Mapper.Map<CommentViewModel, Comment>(comment);
                _commentApp.Add(commentDomain);

                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(_productApp.GetAll(), "ProductId", "Name", comment.ProductId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int id)
        {
            var comment = _commentApp.GetById(id);
            var commentViewModel = Mapper.Map<Comment, CommentViewModel>(comment);
            
            ViewBag.ProductId = new SelectList(_productApp.GetAll(), "ProductId", "Name", commentViewModel.ProductId);

            return View(commentViewModel);
        }

        // POST: Comments/Edit/5
        [HttpPost]
        public ActionResult Edit(CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var commentDomain = Mapper.Map<CommentViewModel, Comment>(comment);
                _commentApp.Update(commentDomain);

                return RedirectToAction("Index");
            }

            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int id)
        {
            var comment = _commentApp.GetById(id);
            var commentViewModel = Mapper.Map<Comment, CommentViewModel>(comment);

            return View(commentViewModel);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var comment = _commentApp.GetById(id);
            _commentApp.Remove(comment);

            return RedirectToAction("Index");
        }

        // GET: Comments/Edit/5
        public ActionResult AddNewComment(int idProduto)
        {
            ViewBag.ProductId = new SelectList(_productApp.GetAll(), "ProductId", "Name", idProduto);

            return View();
        }
    }
}
