<template>
  <div id="header">
    <div class="logo-box">
      <div class="toggle">
        <div class="fas fa-bars"></div>
      </div>
      <div class="logo"></div>
    </div>

    <div class="toolbar">
      <div class="dropdown">
        <button
          class="btn btn-link dropdown-toggle"
          type="button"
          id="dropdownMenuButton1"
          data-bs-toggle="dropdown"
          aria-expanded="false"
        >
          <i class="fas fa-user"></i>
        </button>
        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
          <li><a class="dropdown-item" href="#">Action</a></li>
          <li><a class="dropdown-item" href="#">Another action</a></li>
          <li><a class="dropdown-item" href="#">Something else here</a></li>
        </ul>
      </div>
    </div>
  </div>
</template>