using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GithubUserSearch.Models;
using Octokit;

namespace GithubUserSearch.Controllers
{
    public class HomeController : Controller
    {
        public static List<History> HistoryList = new List<History>();
        public async Task<IActionResult> Index(string username)
        {

            try
            {
                if (string.IsNullOrEmpty(username))
                {
                    TempData["Message"] = "Please insert a username to start the search!";
                    return View();
                }
                else
                {
                    var github = new GitHubClient(new ProductHeaderValue("MyDemoApp"));
                    var user = await github.User.Get(username);

                    addHistory(user);

                    return View(user);
                }
            }

            catch (NotFoundException objectNotFound)
            {
                TempData["Message"] = "Failed to get user info : " + objectNotFound.Message;
                return View();


            }
            catch (Exception)
            {
                TempData["Message"] = "Something went wrong with the search! Please try again!";
                return View();
            }
        }

        private void addHistory(User user){
            try{

                var duplicate = HistoryList.Find(x => x.userId == user.Id);
                
                if(duplicate is null){
                    HistoryList.Add( new History{ 
                        userName = user.Name,
                        userId = user.Id,
                        userLogin = user.Login,
                        userLocation = user.Location,
                        userFollowers = user.Followers,
                        userHtmlUrl = user.HtmlUrl,
                        userBlog = user.Blog,
                        userCompany = user.Company,
                        userAvatar = user.AvatarUrl,
                        searchDate = DateTime.Now
                        });
                    };
                

            }catch(Exception){
                TempData["Message"] ="Unable to record! Please try again";
            }
        }


        public IActionResult About()
        {
            ViewData["Message"] = "This website is a simple webiste to search github user and temporary store search result.";

            return View();
        }

        public IActionResult Contact()
        {

            var display = HistoryList.Select(x => x).OrderBy(x => x.searchDate);

            if(!display.Any()){
            ViewData["Message"] = "Your history page is empty.";

            }else{
                ViewData["Message"] = "Display search history result.";
            }

            return View(display);
        }

        

    }
}
