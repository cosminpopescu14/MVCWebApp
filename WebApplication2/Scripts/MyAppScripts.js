function Send() {

    var Data = {
        content: $("#editor").val()//getting the data from editor
    }

    $.ajax({
        contentType: "application/json; charset=utf-8",
        url: "/Home/WriteInFileFromKendoEditor",//controller and action from it
        type: "POST",
        data: JSON.stringify(Data)

    });
}