
async function ListComment(id = undefined) {
    $("#ProductTableRow").html($loading);
    $TempObject = {};
    $result = await AjaxCall("GET", '/Admin/Comment/ListComments' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#ProductTableRow").html($result);
    console.log($result);
    //$("ul.pagination li").removeAttr("disabled");
    //$(`ul.pagination li:nth-child(${pageindex})`).removeAttr("disabled");
}
ListComment();


async function ListContactUs(id = undefined) {
    $("#Product2TableRow").html($loading);
    $TempObject = {};
    $result = await AjaxCall("GET", '/Admin/Comment/ListContactUs' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#Product2TableRow").html($result);
    console.log($result);
    //$("ul.pagination li").removeAttr("disabled");
    //$(`ul.pagination li:nth-child(${pageindex})`).removeAttr("disabled");
}
ListContactUs();

async function ComnfirmComment(id) {
    if (confirm("آیا از تایید این نظر اطمینان دارید؟ ")) {

        $("#ProductTableRow").html($loading);
        $result = await AjaxCall("GET", `/Admin/Comment/SuccssProductStatus?id=${id}`, $TempObject, 0);
        $("#ProductTableRow").html($result);
        $("#currentid").val(id);
        ListComment(id = undefined)
    }
}


async function RejectdProductStatus(id) {
    if (confirm("آیا از رد این نظر اطمینان دارید؟ ")) {
        $("#ProductTableRow").html($loading);
        $result = await AjaxCall("GET", `/Admin/Comment/RejectdProductStatus?id=${id}`, $TempObject, 0);
        $("#ProductTableRow").html($result);
        $("#currentid").val(id);
        ListComment(id = undefined)
    }
}
