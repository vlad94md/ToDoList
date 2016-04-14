function LoadAllToDos() {
    $('#myTabContent').find("div").removeClass("activeTab");
    $('#toDoAllList').addClass("activeTab");

    $.ajax({
        url: '@Url.Action("GetAllRecords", "ToDo")',
        success: function (data) {
            $('.activeTab').html(data);
        }
    });
}

function LoadOnlyToDos() {
    $('#myTabContent').find("div").removeClass("activeTab");
    $('#toDoOnlyList').addClass("activeTab");

    $.ajax({
        url: '@Url.Action("GetNotFinishedRecords", "ToDo")',
        success: function (data) {
            $('.activeTab').html(data);
        }
    });
}

function LoadDoneToDos() {
    $('#myTabContent').find("div").removeClass("activeTab");
    $('#doneOnlyList').addClass("activeTab");

    $.ajax({
        url: '@Url.Action("GetOnlyDoneRecords", "ToDo")',
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
        url: '@Url.Action("Add", "ToDo")',
        data: { subject: toDoText },
        success: function (data) {
            refreshActiveTab();
        }
    });
}

function DeleteToDo(toDoId) {
    $.ajax({
        url: '@Url.Action("Delete", "ToDo")',
        data: { id: toDoId },
        success: function (data) {
            refreshActiveTab();
        }
    });
}

function DoneToDo(toDoId) {
    $.ajax({
        url: '@Url.Action("Done", "ToDo")',
        data: { id: toDoId },
        success: function (data) {
            refreshActiveTab();
        }
    });
}

function refreshActiveTab(data) {
    var currentTab = $('.activeTab');

    if (currentTab.attr('id') === 'toDoAllList') {
        $.ajax({
            url: '@Url.Action("GetAllRecords", "ToDo")',
            success: function (data) {
                $('.activeTab').html(data);
            }
        });
    }
    else
        if (currentTab.attr('id') === 'toDoOnlyList') {
            $.ajax({
                url: '@Url.Action("GetNotFinishedRecords", "ToDo")',
                success: function (data) {
                    $('.activeTab').html(data);
                }
            });
        }
        else
            if (currentTab.attr('id') === 'doneOnlyList') {
                $.ajax({
                    url: '@Url.Action("GetOnlyDoneRecords", "ToDo")',
                    success: function (data) {
                        $('.activeTab').html(data);
                    }
                });
            }
}