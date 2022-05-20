<template>
    <div class="calendar-month block"> <!-- CALENDAR MONTH (RIGHT-CONTAINER) -->
                    <div class="arrow-btn-container">
                        <a class="arrow-btn left" href="#202"><span class="icon fontawesome-angle-left"></span></a>
                        <h2 class="titular">APRIL 2013</h2>
                        <a class="arrow-btn right" href="#203"><span class="icon fontawesome-angle-right"></span></a>
                    </div>
                    <table class="calendar">
                        <thead class="days-week">
                            <tr>
                                <th>S</th>
                                <th>M</th>
                                <th>T</th>
                                <th>W</th>
                                <th>R</th>
                                <th>F</th>
                                <th>S</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td><a class="scnd-font-color" href="#100">1</a></td>
                            </tr>
                            <tr>
                                <td><a class="scnd-font-color" href="#101">2</a></td>
                                <td><a class="scnd-font-color" href="#102">3</a></td>
                                <td><a class="scnd-font-color" href="#103">4</a></td>
                                <td><a class="scnd-font-color" href="#104">5</a></td>
                                <td><a class="scnd-font-color" href="#105">6</a></td>
                                <td><a class="scnd-font-color" href="#106">7</a></td>
                                <td><a class="scnd-font-color" href="#107">8</a></td>
                            </tr>
                            <tr>
                                <td><a class="scnd-font-color" href="#108">9</a></td>
                                <td><a class="scnd-font-color" href="#109">10</a></td>
                                <td><a class="scnd-font-color" href="#110">11</a></td>
                                <td><a class="scnd-font-color" href="#111">12</a></td>
                                <td><a class="scnd-font-color" href="#112">13</a></td>
                                <td><a class="scnd-font-color" href="#113">14</a></td>
                                <td><a class="scnd-font-color" href="#114">15</a></td>
                            </tr>
                            <tr>
                                <td><a class="scnd-font-color" href="#115">16</a></td>
                                <td><a class="scnd-font-color" href="#116">17</a></td>
                                <td><a class="scnd-font-color" href="#117">18</a></td>
                                <td><a class="scnd-font-color" href="#118">19</a></td>
                                <td><a class="scnd-font-color" href="#119">20</a></td>
                                <td><a class="scnd-font-color" href="#120">21</a></td>
                                <td><a class="scnd-font-color" href="#121">22</a></td>
                            </tr>
                            <tr>
                                <td><a class="scnd-font-color" href="#122">23</a></td>
                                <td><a class="scnd-font-color" href="#123">24</a></td>
                                <td><a class="scnd-font-color" href="#124">25</a></td>
                                <td><a class="today" href="#125">26</a></td>
                                <td><a href="#126">27</a></td>
                                <td><a href="#127">28</a></td>
                                <td><a href="#128">29</a></td>
                            </tr>
                            <tr>
                                <td><a href="#129">30</a></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>
    </div>
</template>
<style scoped>
.arrow-btn-container span{
	color:#ffffff;
}       
h2.titular {
	color:#ffffff;
}
.calendar-month {
				height: 380px;
				margin-top:20px;
			}
				.calendar-month .titular {
					background: #3468af;
				}
					.calendar-month .arrow-btn:hover {
						background: #1a4e95;
					}
				.calendar {
					margin: 22px 15px;
					text-align: center;
				}
					.calendar a {
						font-size: 17px;
					}
					.calendar td, .calendar th {
						width: 40px;
						height: 38px;						
					}
					.calendar .days-week {
						color: #4fc4f6;
					}
					.calendar .today {
						display: block;
						width: 34px;
						line-height: 34px;
						background: #e64c65;
						border-radius: 100%;
					}
</style>>