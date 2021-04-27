import { DepartamentDto } from "./departaments/departamentDto";
import { EmployeeInfoDto } from "./EmployeeInfoDto";
import { JobHistoryDto } from "./jobHistory/jobHistoryDto";
import { JobDto } from "./jobs/jobDto";

export class EmployeeInfo implements EmployeeInfoDto {
    Efficiency: number;
    NewDepartamentId: number;
    NewJobId: number;
    NewSalary: number;
    Id: number;
    HireDate: Date;
    Birthday: Date;
    Email: string;
    DepartamentTitle: string;
    JobTitle: string;
    Fired: boolean;
    OnVacation: boolean;
    FirstName: string;
    SecondName: string;
    ThirdName: string;
    Salary: number;
    Depts: DepartamentDto[];
    DepartamentId: number;
    Jobs: JobDto[];
    JobId: number;
    JobHistory: JobHistoryDto[];

}