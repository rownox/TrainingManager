<script>
</script>

<div class="people-container">
    <div class="search">
        <input type="search" placeholder="Search By Name" />
    </div>
    <p>People</p>
    <ul id="people" class="people">
        <li class="person" value="@employee.FirstName @employee.LastName">
            <p>FirstName LastName</p>
            <p class="sub">Status: Status</p>
        </li>
    </ul>
    <p>Groups</p>
    <ul id="groups" class="people">
        <li class="person">
            <p>HR</p>
            <p class="sub">Member Count: 6</p>
        </li>
    </ul>
</div>

<div class="details">
    <div class="top">
        <p class="title">Firstname Lastname</p>
        <div class="info">
            <p class="one">Status:</p>
            <p class="two">Trainer</p>
        </div>
        <div class="info">
            <p class="one">Affiliated groups:</p>
            <p class="two">HR</p>
        </div>
        <div class="info">
            <p class="one">Assigned Trainings:</p>
        </div>
        <div class="trainings">
            <p class="training">Order #183 -+- 22 Hours</p>
            <p class="training">Order #162 -+- 36 Hours</p>
            <p class="training">Order #197 -+- 11 Hours</p>
        </div>
        <div class="info">
            <p class="one">Total Assigned Hours:</p>
            <p class="two">92 Hours</p>
        </div>
    </div>
    
    <div class="bottom">
        <a class="btn btnBlue bg-btn">Add Trainer</a>
    </div>
</div>

<style>

</style>