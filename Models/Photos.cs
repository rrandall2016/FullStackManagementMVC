using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackManagementMVC.Models
{
    public class Photos
    {

       
        
            public Class1[] Property1 { get; set; }
        

        public class Class1
        {
            public string id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public DateTime? promoted_at { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string color { get; set; }
            public string blur_hash { get; set; }
            public string description { get; set; }
            public string alt_description { get; set; }
            public Urls urls { get; set; }
            public Links links { get; set; }
            public object[] categories { get; set; }
            public int likes { get; set; }
            public bool liked_by_user { get; set; }
            public object[] current_user_collections { get; set; }
            public Sponsorship sponsorship { get; set; }
            public Topic_Submissions topic_submissions { get; set; }
            public User user { get; set; }
        }

        public class Urls
        {
            public string raw { get; set; }
            public string full { get; set; }
            public string regular { get; set; }
            public string small { get; set; }
            public string thumb { get; set; }
        }

        public class Links
        {
            public string self { get; set; }
            public string html { get; set; }
            public string download { get; set; }
            public string download_location { get; set; }
        }

        public class Sponsorship
        {
            public string[] impression_urls { get; set; }
            public string tagline { get; set; }
            public string tagline_url { get; set; }
            public Sponsor sponsor { get; set; }
        }

        public class Sponsor
        {
            public string id { get; set; }
            public DateTime updated_at { get; set; }
            public string username { get; set; }
            public string name { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string twitter_username { get; set; }
            public string portfolio_url { get; set; }
            public string bio { get; set; }
            public object location { get; set; }
            public Links1 links { get; set; }
            public Profile_Image profile_image { get; set; }
            public string instagram_username { get; set; }
            public int total_collections { get; set; }
            public int total_likes { get; set; }
            public int total_photos { get; set; }
            public bool accepted_tos { get; set; }
            public bool for_hire { get; set; }
            public Social social { get; set; }
        }

        public class Links1
        {
            public string self { get; set; }
            public string html { get; set; }
            public string photos { get; set; }
            public string likes { get; set; }
            public string portfolio { get; set; }
            public string following { get; set; }
            public string followers { get; set; }
        }

        public class Profile_Image
        {
            public string small { get; set; }
            public string medium { get; set; }
            public string large { get; set; }
        }

        public class Social
        {
            public string instagram_username { get; set; }
            public string portfolio_url { get; set; }
            public string twitter_username { get; set; }
            public object paypal_email { get; set; }
        }

        public class Topic_Submissions
        {
            public BusinessWork businesswork { get; set; }
            public Nature nature { get; set; }
            public Wallpapers wallpapers { get; set; }
            public Travel travel { get; set; }
            public People people { get; set; }
        }

        public class BusinessWork
        {
            public string status { get; set; }
            public DateTime approved_on { get; set; }
        }

        public class Nature
        {
            public string status { get; set; }
        }

        public class Wallpapers
        {
            public string status { get; set; }
        }

        public class Travel
        {
            public string status { get; set; }
        }

        public class People
        {
            public string status { get; set; }
        }

        public class User
        {
            public string id { get; set; }
            public DateTime updated_at { get; set; }
            public string username { get; set; }
            public string name { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string twitter_username { get; set; }
            public string portfolio_url { get; set; }
            public string bio { get; set; }
            public string location { get; set; }
            public Links2 links { get; set; }
            public Profile_Image1 profile_image { get; set; }
            public string instagram_username { get; set; }
            public int total_collections { get; set; }
            public int total_likes { get; set; }
            public int total_photos { get; set; }
            public bool accepted_tos { get; set; }
            public bool for_hire { get; set; }
            public Social1 social { get; set; }
        }

        public class Links2
        {
            public string self { get; set; }
            public string html { get; set; }
            public string photos { get; set; }
            public string likes { get; set; }
            public string portfolio { get; set; }
            public string following { get; set; }
            public string followers { get; set; }
        }

        public class Profile_Image1
        {
            public string small { get; set; }
            public string medium { get; set; }
            public string large { get; set; }
        }

        public class Social1
        {
            public string instagram_username { get; set; }
            public string portfolio_url { get; set; }
            public string twitter_username { get; set; }
            public object paypal_email { get; set; }
        }

    }
}
