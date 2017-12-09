using Codifico.SemiSenior.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Codifico.SemiSenior.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string[] cardsValues = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "ace", "jack", "queen", "king" };
            string[] cardsTypes = { "spades", "hearts", "diamonds", "clubs" };
            List<Card> totalCards = new List<Card>();
            List<Card> cardsSelected = new List<Card>();

            foreach (string typeContext in cardsTypes)
            {
                foreach (string valueContext in cardsValues)
                {
                    totalCards.Add(new Card { id = totalCards.Count + 1, imgPath = "/Content/cards/" + valueContext + "_of_" + typeContext + ".png", type = typeContext, value = valueContext });
                    if (valueContext.Equals("ace") || valueContext.Equals("jack") || valueContext.Equals("queen") || valueContext.Equals("king"))
                    {
                        totalCards.Add(new Card { id = totalCards.Count + 1, imgPath = "/Content/cards/" + valueContext + "_of_" + typeContext + "2.png", type = typeContext, value = valueContext });
                    }
                }
            }

            totalCards.Add(new Card { id = totalCards.Count + 1, imgPath = "/Content/cards/red_joker.png", type = "joker", value = "joker" });
            totalCards.Add(new Card { id = totalCards.Count + 1, imgPath = "/Content/cards/black_joker.png", type = "joker", value = "joker" });
            int? ranControl = null;

            Random rnd = new Random();

            int[] indexSelected = { rnd.Next(0, 70), rnd.Next(0, 70), rnd.Next(0, 70), rnd.Next(0, 70), rnd.Next(0, 70) };

            for (int i = 0; i < indexSelected.Length; i++)
            {
                int ranContext = indexSelected[i];

                while (ranContext == ranControl)
                {
                    ranContext = rnd.Next(0, 70);
                }

                cardsSelected.Add(totalCards.ElementAt(ranContext));
                ranControl = ranContext;
            }

            return View(cardsSelected);
        }

    }
}