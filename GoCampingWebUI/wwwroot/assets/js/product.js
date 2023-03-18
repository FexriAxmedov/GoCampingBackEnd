$(document).ready(function () {
    $(".const").removeClass("dropdown");
  });
  $(".pages").click(function () {
    $(".const").toggleClass("dropdown");
  });
 
  const sr = ScrollReveal();
  sr.reveal(".header-full", {
    origin: "top",
    duration: 2000,
    delay: 300,
  });
  sr.reveal(".footertop-items", {
    delay: 600,
  });
  sr.reveal(".footerbottom-items", {
    delay: 600,
  });
  sr.reveal(".goback",{
    delay:600
  });
sr.reveal(".imagecarousel",{
delay:700,
origin:"left",
distance:"40px"
});
sr.reveal(".imagedetails",{
  delay:700,
  origin:"right",
  distance:"40px"
  });
  sr.reveal(".featuredh1", {
    origin: "top",
    distance: "10px",
    duration: 2000,
    delay: 1000,
  });
  
  sr.reveal(".box1", {
    delay:500
  });
  sr.reveal(".box2", {
    delay:550
  });

  const cartIcon = document.querySelector("#cart-icon");
const cart = document.querySelector(".cart");
const closeCart = document.querySelector("#cart-close");


cartIcon.addEventListener("click",()=>{
  cart.classList.add("active");
});

closeCart.addEventListener("click",()=>{
  cart.classList.remove("active");
});

if(document.readyState == "loading"){
  document.addEventListener('DOMContentLoaded',start);
}else{
  start();
}


function start(){
  addEvents();
}

function update(){
addEvents();
}

function addEvents(){
 let cart_remove_btns = document.querySelectorAll('.cart-remove');
 console.log(cart_remove_btns);
 cart_remove_btns.forEach((btn)=>{
btn.addEventListener("click",handle_removeCartItem)
 });
}

function handle_removeCartItem(){
  this.parentElement.remove();

  update();
}

function scrollUp() {
    const scrollUp = document.getElementById("scroll-up");
    // When the scroll is higher than 460 viewport height, add the show-scroll class to the a tag with the scroll-top class
    if (this.scrollY >= 460) scrollUp.classList.add("show-scroll");
    else scrollUp.classList.remove("show-scroll");
  }
  window.addEventListener("scroll", scrollUp);
  




  function myFunction(smallImg){
    var fullImg = document.getElementById("imageBox");
fullImg.src = smallImg.src;
  }