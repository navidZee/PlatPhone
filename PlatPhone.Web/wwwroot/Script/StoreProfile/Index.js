async function LoadProfile(id = undefined) {
    $("#profileview").html($loading);
    console.log(id);
    $result = await AjaxCall("GET", '/Admin/StoreProfile/ShowProfile' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#profileview").html($result);
}
LoadListStoreConfirm();