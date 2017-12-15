var tabControl = {
    initialize: function () {
        var lastClicked;
        var lastFragment;

        var tab = document.getElementsByClassName("tab-control");
        var ul = tab[0].getElementsByTagName("ul");
        var items = ul[0].getElementsByTagName("li");
        var arr = Array.from(items);

        for (i = 0; i < arr.length; i++){
            arr[i].id = i + 1;
            var link = arr[i].getElementsByTagName("a");
            link[0].href = "#fragment-x" + (i + 1);
        }

        doFistTabActive();

       

        var onTabClick = function callback(e) {
            var e = window.e || e;

            if (e.target.tagName !== 'LI')
                return;

            e.target.classList.add("tab-active");
            var fragment = document.getElementById("f-" + e.target.id);

            fragment.classList.add("fragment-active");

            if (lastClicked) {
                if (lastClicked.id != e.target.id) {
                    lastClicked.classList.remove("tab-active");
                    lastFragment.classList.remove("fragment-active");
                    lastClicked = e.target;
                    lastFragment = fragment;
                }
            }
            else {
                lastFragment = fragment;
                lastClicked = e.target;
            }
        }

        subscribeToTabClicks();

        function subscribeToTabClicks() {
            if (document.addEventListener)
                document.addEventListener('click', onTabClick, false);
            else
                document.attachEvent('onclick', onTabClick);
        }

        function doFistTabActive() {
            arr[0].classList.add("tab-active");
            var fragment = document.getElementById("f-" + arr[0].id);
            fragment.classList.add("fragment-active");
            lastClicked = arr[0];
            lastFragment = fragment;
        }
    }
}