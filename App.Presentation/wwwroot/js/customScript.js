const stars = document.querySelectorAll(".rating span");
const rateInput = document.getElementById("RateInput");

stars.forEach(star => {
    // Hover
    star.addEventListener("mouseover", function () {
        const value = this.getAttribute("data-value");
        highlightStars(value);
    });

    star.addEventListener("mouseout", function () {
        highlightStars(rateInput.value);
    });

    // Click => انتخاب امتیاز
    star.addEventListener("click", function () {
        const value = this.getAttribute("data-value");
        rateInput.value = value;
        highlightStars(value);
    });
});

function highlightStars(value) {
    stars.forEach(star => {
        star.classList.remove("hover", "selected");
        if (star.getAttribute("data-value") <= value) {
            star.classList.add("selected");
        }
    });
}