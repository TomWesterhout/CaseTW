import { CursusInstantie } from './cursus-instantie';

export class Cursus {
    id: number;
    duur: number;
    titel: string;
    code: string;
    cursusInstanties: CursusInstantie[];
}
