let deleteId = null;

function toggleDone(id, checkbox) {
    fetch('/ListItems/ToggleDone', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ id: id })
    })
        .then(res => {
            if (!res.ok) {
                checkbox.checked = !checkbox.checked;
                alert("Update Error");
                return;
            }

            const item = checkbox.closest('.item');
            item.classList.toggle('done');
        });
}

function rename(id, input) {
    fetch('/ListItems/Rename', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ id, text: input.value })
    });
}

function openDelete(id) {
    deleteId = id;
    document.getElementById('deleteModal').style.display = 'block';
}

function closeDelete() {
    deleteId = null;
    document.getElementById('deleteModal').style.display = 'none';
}

function confirmDelete() {
    fetch('/ListItems/DeleteAjax', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ id: deleteId })
    }).then(() => location.reload());
}