import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';

@Component({
  selector: 'app-employee-add-form',
  templateUrl: './employee-add-form.component.html',
  styleUrls: ['./employee-add-form.component.css']
})
export class EmployeeAddFormComponent implements OnInit {
  employeeCreateForm: FormGroup;
  isSubmit= false;

  firstNameBackEndErrors: string[];
  lastNameBackEndErrors: string[];
  emailAddressBackEndErrors: string[];
  officeBackEndErrors: string[];

  constructor(
    private employeeService: EmployeeService,
    private employeeDataService: EmployeeDataService
  ) { 
    //sets front-end max length
    this.employeeCreateForm = new FormGroup({
      firstname: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      lastname: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      emailaddress: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      office: new FormControl('', [Validators.required, Validators.maxLength(50)])
    })
  }

  ngOnInit() {
  }

  get f() { return this.employeeCreateForm.controls; }

  async onFormSubmit() {
    let ok = confirm("are you sure you want to submit");
    //end function if user did not confirm
    if(!ok){
      return;
    }

    if(!this.employeeCreateForm.valid){
      return;
    }

    try{
      this.isSubmit = true;
      this.firstNameBackEndErrors = null;
      this.lastNameBackEndErrors = null;
      this.emailAddressBackEndErrors = null;
      this.officeBackEndErrors = null;
      let result = await this.employeeService.CreateEmployee(this.employeeCreateForm.value).toPromise();
      if(result.isSuccess){
        alert(result.message);
        this.employeeCreateForm.reset();
        this.employeeDataService.refreshEmployees();
      } 
      else {
        alert(result.message);
      }
    }
    catch(error){
      console.error(error);
      let errs = error.error

      if(errs.isSuccess===false){
        alert(errs.message);
        return;
      }

      if(errs.errors) {
        if('firstname' in errs.errors){
          this.firstNameBackEndErrors = errs.errors.firstname;//shows data annotations error message
        }
        if('firstname' in errs.errors){
          this.lastNameBackEndErrors = errs.errors.lastname;//shows data annotations error message
        }
        if('firstname' in errs.errors){
          this.emailAddressBackEndErrors = errs.errors.emailaddress;//shows data annotations error message
        }
        if('firstname' in errs.errors){
          this.officeBackEndErrors = errs.errors.office;//shows data annotations error message
        }
      }

      this.isSubmit = false;//enables button
    }
    finally{
      this.isSubmit = false;//enables button
    }
  }

}
