function LoadAllToDos() {
    $('#myTabContent').find("div").removeClass("activeTab");
    $('#toDoAllList').addClass("activeTab");

    $.ajax({
        url: "ToDo/GetAllRecords",
        success: function (data) {
            $('.activeTab').html(data);
        }
    });
}

function LoadOnlyToDos() {
    $('#myTabContent').find("div").removeClass("activeTab");
    $('#toDoOnlyList').addClass("activeTab");

    $.ajax({
        url: "ToDo/GetNotFinishedRecords",
        success: function (data) {
            $('.activeTab').html(data);
        }
    });
}

function LoadDoneToDos() {
    $('#myTabContent').find("div").removeClass("activeTab");
    $('#doneOnlyList').addClass("activeTab");

    $.ajax({
        url: "ToDo/GetOnlyDoneRecords",
        success: function (data) {
            $('.activeTab').html(data);
        }
    });
}

function AddToDo() {
    var toDoText = $("#toDoInput").val();
    $("#toDoInput").val("");

    $.ajax({
        type: "POST",
        url: "ToDo/Add",
        data: { subject: toDoText },
        success: function (data) {
            refreshActiveTab();
        }
    });
}

function DeleteToDo(toDoId) {
    $.ajax({
        url: "ToDo/Delete",
        data: { id: toDoId },
        success: function (data) {
            refreshActiveTab();
        }
    });
}

function DoneToDo(toDoId) {
    $.ajax({
        url: "ToDo/Done",
        data: { id: toDoId },
        success: function (data) {
            refreshActiveTab();
        }
    });
}

function refreshActiveTab(currentPage) {
    var currentTab = $('.activeTab');

    if (currentPage == undefined) {
        currentPage = 1;
    }

    if (currentTab.attr('id') === 'toDoAllList') {
        $.ajax({
            url: "ToDo/GetAllRecords",
            data: { page: currentPage },
            success: function (data) {
                $('.activeTab').html(data);
            }
        });
    }
    else
        if (currentTab.attr('id') === 'toDoOnlyList') {
            $.ajax({
                url: "ToDo/GetNotFinishedRecords",
                data: { page: currentPage },
                success: function (data) {
                    $('.activeTab').html(data);
                }
            });
        }
        else
            if (currentTab.attr('id') === 'doneOnlyList') {
                $.ajax({
                    url: "ToDo/GetOnlyDoneRecords",
                    data: { page: currentPage },
                    success: function (data) {
                        $('.activeTab').html(data);
                    }
                });
            }
}