$(document).ready(function () {
    var arrayQues = new Array();
    arrayQues = [];
    $("#tblQuesSurvey").on('click', '.add', function () {
        if (confirm('are you sure?')) {
            var currentRow = $(this).closest("tr");
            var idQuestion = currentRow.find("td:eq(0)").text();
            arrayQues.push(parseInt(idQuestion));
            currentRow.remove();
        }
    })
    $("#addSurvey").submit(function (e) {
        e.preventDefault();
        var name = $("#Name").val();
        var active = $("#Active").val();
        var des = $("#desc").val();
        var updated = $("#Updated").val();
        $.ajax({
            type: "POST",
            url: "/admin/survey/create",
            data: {
                name: name,
                updated: updated,
                des: des,
                active: active,
                arrayQues: arrayQues
            }
        })
    })

    $("#addQuesSur").on('show.bs.modal', function () {
        var idSurvey = $("#addQuesSur #idSurvey").val();
        $.ajax({
            type: 'GET',
            url: '/admin/survey/findQuestion',
            data: {
                idSurvey: idSurvey
            },
            contentType: '/application/json; charset=utf-8',
            dataType: 'json',
            success: function (question) {

                var result = '';
                if (question.length > 0) {
                    for (var i = 0; i < question.length; i++) {
                        result += '<tr><td>' + question[i].id + '</td>';
                        result += '<td>' + question[i].question1 + '</td>';
                        result += '<td>';
                        result += '<button class="btn btn-gradient-success addQuesSur" type = "button" >ADD</button >';
                        result += '</td ></tr >';
                    }
                } else {
                    result += '<div class="alert alert-danger" role="alert">THERE IS NO DATA!!!</div >';
                }
                $('#bodyaddQuesSur').html(result);

            }
        })
    });
    $("#addQuesSur2").on("click", ".addQuesSur", function () {
        if (confirm('are you sure?')) {
            var currentRow = $(this).closest("tr");
            var idQuestion = currentRow.find("td:eq(0)").text();
            var idSurvey = $("#addQuesSur #idSurvey").val();
            $.ajax({
                type: "POST",
                url: "/admin/survey/addQues",
                data: {
                    idSurvey: idSurvey,
                    idQuestion: idQuestion
                },
                success: function (question) {
                    var result = '';
                    for (var i = 0; i < question.length; i++) {
                        result += '<tr><td>' + question[i].id + '</td>';
                        result += '<td>' + question[i].question1 + '</td>';
                        result += '<td><button class="btn btn-lg btn-gradient-primary ">del</button></td ></tr>';
                    }
                    $('#bodyq').html(result);
                    alert("success!!")
                    $("#addQuesSur2").modal("hide");
                }
            })
        }
    })

    $("#quesSur").on('click', '.delQuesSur', function () {
        if (confirm('are you sure?')) {
            var currentRow = $(this).closest("tr");
            var idQuestion = currentRow.find("td:eq(0)").text();
            var idSurvey = $("#addQuesSur #idSurvey").val();
            $.ajax({
                type: "GET",
                url: "/admin/survey/delQues",
                data: {
                    idSurvey: idSurvey,
                    idQuestion: idQuestion
                },
                success: function (question) {
                    var result = '';
                    for (var i = 0; i < question.length; i++) {
                        result += '<tr><td>' + question[i].id + '</td>';
                        result += '<td>' + question[i].question1 + '</td>';
                        result += '<td><button class="btn btn-lg btn-gradient-primary ">del</button></td ></tr>';
                    }
                    $('#bodyq').html(result);
                    alert("success!!")
                }
            })
        }
    })
})