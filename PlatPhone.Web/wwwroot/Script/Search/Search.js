
//var categories = [];
//var userLanguageKey = $('#userLanguageKey').val();

//$("#searchCategorisView").click(function () {
//    setTimeout(function () {
//        $(this).toggleClass("open");
//    }, 100);     
//});

//$("#searchCategorisView ul").delegate("li", "click", function () {
//    let $this = $(this);
//    $("#searchCategorisView ul li.selected").removeClass("selected");
//    $this.addClass("selected");
//    $("#searchCategoris").val($this.data("value"));
//    $("#searchCategorisView span.current").text($this.text());
//});

//function getCategoris() {
//    $.get(`/api/Businesses/GetGroupFilter?language=${userLanguageKey}`, function (result) {
//        if (result.success) {
//            categories = result.data;
//            setSearchCategories();
//        }
//        else
//            console.error("Error get Articles");
//    });
//}
//getCategoris();

//function Search() {
//    let category = $("#searchCategoris").val();
//    location.href = `/Business/AllBussiness?Groups=[${category === "0" ? `` : category}]&Address=${$("#address").val()}&keyWord=${$("#keyWord").val()}`;
//}

//function setSearchCategories() {
//    $.each(categories, function (key, item) {
//        $("#searchCategoris").append(`<option value="${item.value}">${item.title}</option>`);
//        $("#searchCategorisView ul").append(`<li data-value="${item.value}" class="option">${item.title}</li>`);
//    });
//}

function search() {

    var $category = $("ul#listCat li.selected").attr("data-value");
    var $address = $("input#address").val();
    var $keyWord = $("input#keyWord").val();

    location.href = `/Product/ListProduct?keyWord=${$keyWord}&Address=${$address}&Groups=${$category}`;
}
