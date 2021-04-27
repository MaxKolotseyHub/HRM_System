import { DepartamentDto } from "./departaments/departamentDto";
import { JobHistoryDto } from "./jobHistory/jobHistoryDto";
import { JobDto } from "./jobs/jobDto";

export interface EmployeeInfoDto {
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
    Efficiency: number;
    Jobs: JobDto[];
    JobId: number;
    JobHistory: JobHistoryDto[];
    NewDepartamentId: number;
    NewJobId: number;
    NewSalary: number;
}