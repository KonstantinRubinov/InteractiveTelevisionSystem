import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Program } from '../../models/basics/program';
import { programsUrl } from 'src/environments/environment';
import { NgRedux } from 'ng2-redux';
import { Store } from '../../redux/store';
import { Action } from '../../redux/action';
import { ActionType } from '../../redux/action-type';
import { LogService } from '../log.service';

@Injectable({
  providedIn: 'root'
})
export class ProgramService {

  constructor(private http: HttpClient,
              private redux:NgRedux<Store>,
              private logger: LogService) { }


  public GetAllPrograms(): void {
    let observable = this.http.get<Program[]>(programsUrl, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(allPrograms=>{
      const action: Action={type:ActionType.GetAllPrograms, payload:allPrograms};
      this.redux.dispatch(action);
      this.logger.debug("GetAllPrograms: ", allPrograms);
    }, allProgramsError => {
      const action: Action={type:ActionType.GetAllProgramsError, payload:allProgramsError.message};
      this.redux.dispatch(action);
      this.logger.error("GetAllProgramsError: ", allProgramsError.message);
    });
  }

  public GetOneProgramById(programId: number): void {
    let observable = this.http.get<Program>(programsUrl+programId, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(program=>{
      const action: Action={type:ActionType.GetProgram, payload:program};
      this.redux.dispatch(action);
      this.logger.debug("GetProgram: ", program);
    }, programError => {
      const action: Action={type:ActionType.GetProgramError, payload:programError.message};
      this.redux.dispatch(action);
      this.logger.error("GetProgramError: ", programError.message);
    });
  }


  public AddProgram(program: Program): void {
    let observable = this.http.post<Program>(programsUrl, program, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(addedProgram=>{
      const action: Action={type:ActionType.AddProgram, payload:addedProgram};
      this.redux.dispatch(action);
      this.logger.debug("AddProgram: ", addedProgram);
    }, addedProgramError => {
      const action: Action={type:ActionType.AddProgramError, payload:addedProgramError.message};
      this.redux.dispatch(action);
      this.logger.error("AddProgramError: ", addedProgramError.message);
    });
  }


  public UpdateProgram(program: Program): void {
    let observable = this.http.put<Program>(programsUrl + program.programId, program, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(updatedProgram=>{
      const action: Action={type:ActionType.UpdateProgram, payload:updatedProgram};
      this.redux.dispatch(action);
      this.logger.debug("UpdateProgram: ", updatedProgram);
    }, updatedProgramError => {
      const action: Action={type:ActionType.UpdateProgramError, payload:updatedProgramError.message};
      this.redux.dispatch(action);
      this.logger.error("UpdateProgramError: ", updatedProgramError.message);
    });
  }

  public DeleteProgram(programId: number): void {
    let observable = this.http.delete<Program>(programsUrl + programId, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(deletedProgram=>{
      const action: Action={type:ActionType.DeleteProgram, payload:deletedProgram};
      this.redux.dispatch(action);
      this.logger.debug("DeleteProgram: ", deletedProgram);
    }, deletedProgramError => {
      const action: Action={type:ActionType.DeleteProgramError, payload:deletedProgramError.message};
      this.redux.dispatch(action);
      this.logger.error("DeleteProgramError: ", deletedProgramError.message);
    });
  }
  

  // getPrograms(msg:string): Observable<Program[]> {
  //   // TODO: send the message _after_ fetching the heroes
  //   return this.http.get<Program[]>(programsUrl + 'all')
  //   .pipe(
  //     tap(_ => this.log('fetched programs')),
  //     catchError(this.handleError('getPrograms', []))
  //   );
  // }

  // getProgram(id: number): Observable<Program> {
  //   const url = `${programsUrl + 'id'}/${id}`;
  //   return this.http.get<Program>(url)
  //   .pipe(
  //     tap(_ => this.log(`ProgramService: program id=${id}`)),
  //     catchError(this.handleError<Program>(`getProgram id=${id}`))
  //   );
  // }

  // updateProgram (program: Program): Observable<any> {
  //   const url = `${programsUrl}/${program.programId}`;
  //   return this.http.put(url, program, httpOptions)
  //   .pipe(
  //     tap(_ => this.log(`updated program id=${program.programId}`)),
  //     catchError(this.handleError<any>('updateProgram'))
  //   );
  // }

  // addProgram (program: Program): Observable<Program> {
  //   return this.http.post<Program>(programsUrl, program, httpOptions)
  //   .pipe(
  //     tap((customer: Program) => this.log(`added program w/ name=${program.programName}`)),
  //     catchError(this.handleError<Program>('addProgram'))
  //   );
  // }

  // deleteProgram (program: Program | number): Observable<Program> {
  //   const id = typeof program === 'number' ? program : program.programId;
  //   const url = `${programsUrl}/${id}`;
  //   return this.http.delete<Program>(url, httpOptions)
  //   .pipe(
  //     tap(_ => this.log(`deleted program id=${id}`)),
  //     catchError(this.handleError<Program>('deleteProgram'))
  //   );
  // }
}
