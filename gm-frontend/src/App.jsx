import React, { Component } from 'react';
import { Doughnut, Bar } from 'react-chartjs-2';
import './App.css';
import spinner from './loadingSpinner.gif'
import BootstrapTable from 'react-bootstrap-table-next';
import '../node_modules/react-bootstrap-table-next/dist/react-bootstrap-table2.min.css';
import '../node_modules/bootstrap/dist/css/bootstrap.css'



class App extends Component {
	constructor(props) {
		super();
		this.state = {
			TimeSheetEntries: [],
			BillableHours: null,
			NonBillableHours: null,
			TotalHoursTracked: null,
			TotalBillableAmount: null,
			isLoading: true
		};

	}
	async componentDidMount() {
		try {
			const response = await fetch('http://localhost:5000/api/TimeSheetEntry');
			const data = await response.json();		
			await this.setStateAsync({ TimeSheetEntries: data })
				
			this.getBillableHours();
			this.getTotalHoursTracked();
			this.getTotalBillableAmount();
			this.getBillableHours();
			this.getNonBillableHours();
			this.setState({ isLoading: false })
		}catch (error) {
			console.log(error);
	    }
			
	}
	setStateAsync(state) {
		return new Promise((resolve) => {
		  this.setState(state, resolve)
		});
	  }
	getTimeSheetEntries(billable) {
		return this.state.TimeSheetEntries.filter(function (ts) {
			return ts.billable === billable;
		});
	}
	getBillableHours() {
		var billableTimeSheetEntries = this.getTimeSheetEntries(true);
		var billableHours = 0;
		billableTimeSheetEntries.map(function (ts) {
			billableHours += ts.billableHours;
			return ts;
		});
		this.setState({ BillableHours: billableHours.toFixed(2) })
	}
	getNonBillableHours() {
		var billableTimeSheetEntries = this.getTimeSheetEntries(false);
		var nonBillableHours = 0;
		billableTimeSheetEntries.map(function (ts) {
			nonBillableHours += ts.hoursRounded;
			return ts;
		});
		this.setState({ NonBillableHours: nonBillableHours.toFixed(2) })
	}
	getTotalHoursTracked() {
		var totalHours = 0;
		this.state.TimeSheetEntries.map(function (ts) {
			totalHours += ts.hoursRounded;
			return ts;
		});
		this.setState({ TotalHoursTracked: totalHours.toFixed(2) })
	}
	getTotalBillableAmount() {
		var billableTimeSheetEntries = this.getTimeSheetEntries(true);
		var billableAmount = 0;
		billableTimeSheetEntries.map(function (ts) {
			billableAmount += ts.billableAmount;
			return ts;
		});
		this.setState({ TotalBillableAmount: "$" + billableAmount.toFixed(2) })
	}
	render() {
		const columns = [{
			dataField: 'fullName',
			text: 'Name'
		}, {
			dataField: 'hoursRounded',
			text: 'Hours'
		}, {
			dataField: 'client',
			text: 'Client'
		}, {
			dataField: 'billableHours',
			text: 'Billable Hours'
		}, {
			dataField: 'billableAmountFormatted',
			text: 'Billable Amount'
		}];
		const data = {
			labels: [
				'Billable',
				'Non Billable'
			],
			datasets: [{
				label: 'Temperature',
				data: [this.state.BillableHours, this.state.NonBillableHours],
				backgroundColor: [
					'#FF6384',
					'#36A2EB',
					'#FFCE56'
				],
				hoverBackgroundColor: [
					'#FF6384',
					'#36A2EB',
					'#FFCE56'
				]
			}]
		};
		return (
			<div className="App">
				<div className="row">
					<div className="col-md-4 col-centered"><h5>Hours Tracked</h5></div>
					<div className="col-md-4 col-centered"><h5>Billable Hours</h5></div>
					<div className="col-md-4 col-centered"><h5>Billable Amount</h5></div>
				</div>
				<div className="row">
					<div className="col-md-4 col-centered"><h1>{this.state.TotalHoursTracked}</h1></div>
					<div className="col-md-4 col-centered">
						<Doughnut
							options={{
								responsive: true,
								maintainAspectRatio: true,
							}}
							data={data}
						/>
					</div>
					<div className="col-md-4 col-centered"><h1>{this.state.TotalBillableAmount}</h1></div>
				</div>
				<header className="col-centered">
				    { this.state.isLoading ? <img src={spinner} alt="loading..." /> : null }
					<BootstrapTable keyField='id' data={this.state.TimeSheetEntries} columns={columns} />					
				</header>
			</div>
		);
	}
}

export default App;
