using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace priori.francesco._5h.ECommerce.Models;

public  class Carrello : Controller
{

    public IActionResult AddToCarrello(string Componente)
    {
        List<string> Carrello = new List<string>();

        if (ViewData["Carrello"] != null)
        {
            Carrello = (List<string>)ViewData["Carrello"];
        }

        Carrello.Add(Componente);

        ViewData["Carrello"] = Carrello;

        return RedirectToAction("Index");
    }

}

