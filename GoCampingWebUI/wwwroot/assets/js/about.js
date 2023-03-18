$(document).ready(function () {
    $(".const").removeClass("dropdown");
  });
  $(".pages").click(function () {
    $(".const").toggleClass("dropdown");
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


const sr = ScrollReveal();
sr.reveal(".header-full", {
  origin: "top",
  duration: 2000,
  delay: 300,
});
sr.reveal(".basliqimiz", {
  origin: "top",
  duration: 2000,
  delay: 400,
});
sr.reveal(".imageforabout", {
  origin: "top",
  duration: 2000,
  delay: 500,
});
sr.reveal(".hamisi", {
  origin: "top",
  duration: 2000,
  delay: 600,
});
sr.reveal(".footertop-items", {
  delay: 600,
});
sr.reveal(".footerbottom-items", {
  delay: 600,
});

