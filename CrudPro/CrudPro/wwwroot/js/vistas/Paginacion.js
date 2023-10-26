document.addEventListener("DOMContentLoaded", function () {
    const table = document.querySelector(".table");
    const rows = Array.from(table.querySelectorAll("tbody tr"));

    const itemsPerPage = 5; // Cambia esto al número de filas que deseas mostrar por página.
    let currentPage = 1;

    function showPage(page) {
        const startIndex = (page - 1) * itemsPerPage;
        const endIndex = startIndex + itemsPerPage;

        rows.forEach((row, index) => {
            if (index >= startIndex && index < endIndex) {
                row.classList.remove("hidden");
            } else {
                row.classList.add("hidden");
            }
        });
    }

    function updatePagination() {
        const totalPages = Math.ceil(rows.length / itemsPerPage);
        const paginationContainer = document.getElementById("pagination");
        paginationContainer.innerHTML = "";

        for (let i = 1; i <= totalPages; i++) {
            const li = document.createElement("li");
            li.className = "page-item";
            const link = document.createElement("a");
            link.className = "page-link";
            link.href = "#";
            link.textContent = i;
            li.appendChild(link);

            link.addEventListener("click", function () {
                currentPage = i;
                showPage(currentPage);
                updatePagination();
            });

            paginationContainer.appendChild(li);
        }
    }

    showPage(currentPage);
    updatePagination();
});