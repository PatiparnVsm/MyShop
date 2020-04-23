﻿using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using MyShop.DataAccess.InMemeory;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace MyShopUI.Controllers
{
    public class ProductManagementController : Controller
    {
        InMemoryRepository<Product> context;
        InMemoryRepository<ProductCategory> productCategories;

        public ProductManagementController()
        {
            context = new InMemoryRepository<Product>();
            productCategories = new InMemoryRepository<ProductCategory>();
        }
        // GET: ProductManagement
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();

            viewModel.Product = new Product();
            viewModel.ProductCategory = productCategories.Collection();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }

            else
            {
                context.Insert(p);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);
            if (product != null)
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.Product = product;
                viewModel.ProductCategory = productCategories.Collection();
                return View(product);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, string Id)
        {
            Product productToEdit = context.Find(Id);
            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }

                productToEdit.Name = product.Name;
                productToEdit.Description = product.Description;
                productToEdit.Price = product.Price;
                productToEdit.Category = product.Category;
                productToEdit.Image = product.Image;

                context.Update(productToEdit);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id) 
        {
            Product productToDelete = context.Find(Id);
            if (productToDelete != null)
            {
                return View(productToDelete);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product productToDelete = context.Find(Id);
            if (productToDelete != null)
            {
                context.Delete(productToDelete);
                context.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}