var carousel = {
    inidialize: function () {
        var slider = document.getElementsByClassName("myslider");
        var sliderArr = Array.from(slider);
        var sliderTracksCount = 1;

        for (var i = 0; i < sliderArr.length; i++){
            var sliderTrack = sliderArr[i].getElementsByClassName("myslidertrack");
            var sliderTrackArr = Array.from(sliderTrack);
            for (var j = 0; j < sliderTrackArr.length; j++) {
                sliderTrackArr[j].id = "myslidertrack-" + sliderTracksCount;
                var prevBtn = document.createElement("button");
                prevBtn.innerHTML = "prev";
                prevBtn.classList.add("prev-slide-btn");
                prevBtn.addEventListener("click", function () { prev() } );
                $(sliderTrackArr[j]).prepend(prevBtn);

                var nextBtn = document.createElement("button");
                nextBtn.innerHTML = "next";
                nextBtn.classList.add("next-slide-btn");
                nextBtn.addEventListener("click", function () { next() });
                $(sliderTrackArr[j]).append(nextBtn);

                sliderTracksCount++;
            }
        }

        function next() {
            currentFragment = document.getElementsByClassName("fragment-active");
            var id = currentFragment[0].id.substring('fragment-x'.length);
            var slidertrack = document.getElementById("myslidertrack-" + currentFragment[0].id.substring('fragment-x'.length));
            var slides = slidertrack.getElementsByTagName("div");
            var activeSlides = slidertrack.getElementsByClassName("slide-active");
            var activeSlidesArr = Array.from(activeSlides);
            var index = activeSlidesArr[0].dataset.slideIndex - 1;
            if (index >= 0 & (index +2) < slides.length) {
                activeSlidesArr[0].classList.remove("slide-active");
                activeSlidesArr[0].classList.add("slide-notactive");
                slides[index + 2].classList.remove("slide-notactive");
                slides[index + 2].classList.add("slide-active");
            }
            else {

            }
        }

        function prev() {
            currentFragment = document.getElementsByClassName("fragment-active");
            var slidertrack = document.getElementById("myslidertrack-" + currentFragment[0].id.substring('fragment-x'.length));
            var slides = slidertrack.getElementsByTagName("div");
            var activeSlides = slidertrack.getElementsByClassName("slide-active");
            var activeSlidesArr = Array.from(activeSlides);
            var index = activeSlidesArr[1].dataset.slideIndex - 1;
            if ((parseInt(index)) < (slides.length) & (parseInt(index)) - 2 >= 0) {
                if (index <= 2) {
                    activeSlidesArr[1].classList.remove("slide-active");
                    activeSlidesArr[1].classList.add("slide-notactive");
                    slides[index - 2].classList.remove("slide-notactive");
                    slides[index - 2].classList.add("slide-active");
                }
                else {
                    activeSlidesArr[1].classList.remove("slide-active");
                    activeSlidesArr[1].classList.add("slide-notactive");
                    slides[index - 2].classList.remove("slide-notactive");
                    slides[index - 2].classList.add("slide-active");
                }
            }
            else {

            }
        }
    }
}