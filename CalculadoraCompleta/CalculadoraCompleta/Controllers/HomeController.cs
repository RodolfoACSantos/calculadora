using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculadoraCompleta.Controllers
{
    public class HomeController : Controller
    {
        //esta forma nao funcion
        // bool primeiroOperador = true;



        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            //coloca o display inicial a 0
            ViewBag.Display = "0";

            //inicialização dos primeiros valores da calculadora
            Session["primeiroOperador"] = true;
            Session["iniciaOperando"] = true;


            return View();
        }
        // POST: Home
        [HttpPost]
        public ActionResult Index(string bt, string display)
        {

            switch(bt)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":               
                case "8":
                case "9":
                case "0":
                    if ((bool) Session["iniciaOperando"] || display.Equals("0")) display = bt;
                    else display += bt;
                    Session["iniciaOperando"] = false;
                    break;
                case "+/-":
                    display = Convert.ToDouble(display) * -1 + "";
                    break;
                case ",":
                    if (!display.Contains(",")) display = display + ",";
                    break;
                case "+":
                case "-":
                case "x":
                case ":":
                case "=":
                    //se for a primeira vez que se carrega num operador
                    if(!(bool) Session["primeiroOperador"]){
                        //recuperar os valores dos operandos
                        double operando1 = Convert.ToDouble((string)Session["primeiroOperando"]);
                        double operando2 = Convert.ToDouble(display);

                        switch((string)Session["operadorAnterior"])
                        {
                            case "+":
                                display = operando1 + operando2 + "";
                                break;
                            case "-":
                                display = operando1 - operando2 + "";
                                break;
                            case "x":
                                display = operando1 * operando2 + "";
                                break;
                            case ":":
                                display = operando1 / operando2 + "";
                                break;
                        }
                    } //if
                    //guardar os dados do display para utilização futura
                    //guardar o valor do 1º operando
                    Session["primeiroOperando"] = display;
                    //limpar o display
                    Session["iniciaOperando"] = true;
                    if (bt.Equals("=")  ){
                        //marcar o operador como primeiro operador
                        Session["primeiroOperador"] = true;
                    }
                    else
                    {
                    //guardar o valor do operador
                        Session["operadorAnterior"] = bt;
                        Session["primeiroOperador"] = false;

                    }
                    //marcar display para reinicio
                    Session["iniciaOperando"] = true;
                    break;

                case "c":
                    //reiniciar a calculadora
                    Session["iniciaOperando"] = true;
                    Session["primeiroOperador"] = true;
                    display = "0";

                    break;

            }
            ViewBag.Display = display;

            return View();
        }
    }
}