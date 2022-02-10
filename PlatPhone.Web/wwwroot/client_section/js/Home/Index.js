$(function () {
    $.get("/api/Articles/GetEvents", function (res) {
        if (res.success) {
            res.data.forEach(function (element) {
                let date = element.date.split(' ')[0].split('/');
                $("#events").append(setEvents(element.imageUrl, element.group, ginj(date[0], date[1], date[2]), element.title, element.brief));
            });
            $('#events').owlCarousel({
                center: true,
                items: 2,
                loop: false,
                margin: 0,
                responsive: {
                    0: {
                        items: 1
                    },
                    600: {
                        items: 1
                    },
                    767: {
                        items: 1
                    },
                    1000: {
                        items: 1
                    },
                    1400: {
                        items: 1
                    }
                }
            });
        }
        else
            console.error("Error get Events");
    });

    $.get("/api/Articles/GetNews", function (res) {
        if (res.success)
            res.data.forEach(function (element) {
                let date = element.date.split(' ')[0].split('/');
                $("#news").append(setNews(element.imageUrl, element.group, ginj(date[0], date[1], date[2]), element.title, element.brief));
            });
        else
            console.error("Error get News");
    });

    function setNews(imageSrc, Category, Date, Title, Brief) {
        return `<div class="col-lg-6">
                    <a class="box_news" href="#">
                        <figure><img src="${imageSrc}" alt=""></figure>
                        <ul>
                            <li>${Category}</li>
                            <li>${Date.y}/${Date.m}/${Date.d}</li>
                        </ul>
                        <h4>${Title}</h4>
                        <p>${Brief}</p>
                    </a>
                </div>
                <!-- /box_news -->`;
    }

    function setEvents(imageSrc, Category, Date, Title, Brief) {
        return `<div class="item px-3 pt-4">
                    <div class="strip grid">
                        <figure>
                            <a href="detail-restaurant.html"><img src="${imageSrc}" class="img-fluid" alt="" width="400" height="266"><div class="read_more"><span>Read more</span></div></a>
                            <small>${Category}</small>
                        </figure>
                        <div class="wrapper">
                            <h3><a href="detail-restaurant.html">${Title}</a></h3>
                            <p>${Brief}</p>
                            <em class="loc_open">${Date.y}/${Date.m}/${Date.d}</em>
                        </div>
                    </div>
                </div>
                <!-- /item -->`;
    }
});