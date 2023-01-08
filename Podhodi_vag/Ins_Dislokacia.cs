using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podhodi_vag
{
    class Ins_Dislokacia
    {
        public void Vstavka_Dislokacia()
        {
            //Загонка в таблицу Дислокация
            string proverka_temp_dislok = "select count(*) from temp_DISLOKACIA";
            string proverka2 = "select count(nom_vag) as col from temp_dislokacia group by nom_vag having count(nom_vag)>1";
            string proverka3 = "select count(nom_vag) as col from temp_dislokacia2";
            Sql_z sq = new Sql_z();
            string stroka=sq.Oracle_v(in proverka_temp_dislok, out string vihod);
            Console.WriteLine("Строка "+Convert.ToInt32(stroka));
            string stroka1 = sq.Oracle_v(in proverka2, out string vihod1);
            Console.WriteLine("Строка1 " + stroka1);
            string stroka2 = sq.Oracle_v(in proverka3, out string vihod2);
            Console.WriteLine("Строка2 " + stroka2);
            //Проверяем есть ли записи в таблице для Импорта в основную таблицу.
            //if (Convert.ToInt32(stroka) > 2000 && stroka1 is null  Convert.ToInt32(stroka2)>1000)
            if (Convert.ToInt32(stroka) > 2000 && stroka1 is null)
            {             
          
                string del_dis = "DELETE FROM DISLOKACIA";
                Console.WriteLine("Удаляем дислокацию");
                string ins_dis = "INSERT INTO DISLOKACIA (NOM_VAG, ROD_VAG_UCH, KOD_SOB, DATE_NACH, STAN_NACH, DOR_NACH, STR_NACH, STAN_NAZN, DOR_NAZN, STR_NAZN, GRUZPOL, GRUZPOL_OKPO, GRUZOTPR," +
                 "GRUZOTPR_OKPO,KOD_GRZ_GNG,PROB_GRJ,PROB_POR,OS_OTM1,OS_OTM2,OS_OTM3,VES_GRZ,DATE_OP,DOR_RASCH,STAN_OP,KOP_VMD,KOP_PMD,PPV_MEST,PPV_TRANZ,PPV_POR,PPV_GRUJ,PPV_NRP,PPV_RP,VNRP_NEISP," +
                 "VNRP_SPEC_TEX,DOR_SDACH_GOS,DOR_PRIEM_GOS,INDEX_POEZD,NOM_POEZD,NPP_VAG,NOM_PARK,NOM_PUT,KOL_ZPU,KOL_GRJ_KONT,KOL_POR_KONT,NOM_KON1,NOM_KON2,NOM_KON3,NOM_KON4,NOM_KON5,NOM_KON6,NOM_KON7," +
                 " NOM_KON8,NOM_KON9,NOM_KON10,NOM_KON11,NOM_KON12,NOM_KON13,ID_OTPRK,NOM_NAK,UNO,NOM_OTPRK_1,NOM_OTPRK_2,NOM_OTPRK_3,NOM_OTPRK_4,NOM_OTPRK_5,NOM_OTPRK_6,NOM_OTPRK_7,NOM_OTPRK_8,NOM_OTPRK_9," +
                 "NOM_OTPRK_10,NOM_OTPRK_11,NOM_OTPRK_12,NOM_OTPRK_13,ID_OTPRK_DOSYL,UNO_DOSYL,DATE_DOSTAV,RASST_OB,RASST_STAN_OP,RASST_STAN_NAZN,PROST_DN,PROST_СН,PROST_MIN,NORMA_KM, OSTATOK,KOD_GRZ_VYGR," +
                 "PR_OST_GRZ,DATE_OTPR,KOD_PL_OTPR,TARIF,OTM_GOD_VAG,POROG_PROB,PR_OTM,PR_STR,DATE_ZAP,KOD_GRZ_UCH,KDS_T,DVS_T,ID_GRUZPOL,ID_GRUZOTPR,DATE_INS,NAIM_ROD_VAG,NAIM_STAN_NAZN,NAIM_GRUZPOL_OKPO,NAIM_KOD_GRZ, " +
                 "NAIM_STAN_OP,NAIM_KOP_VMD,NAIM_GRUZOTPR_OKPO) SELECT NOM_VAG, ROD_VAG_UCH, KOD_SOB, DATE_NACH, STAN_NACH, DOR_NACH, STR_NACH, STAN_NAZN, DOR_NAZN, STR_NAZN, GRUZPOL, GRUZPOL_OKPO, GRUZOTPR," +
                 "GRUZOTPR_OKPO,KOD_GRZ_GNG,PROB_GRJ,PROB_POR,OS_OTM1,OS_OTM2,OS_OTM3,VES_GRZ,DATE_OP,DOR_RASCH,STAN_OP,KOP_VMD,KOP_PMD,PPV_MEST,PPV_TRANZ,PPV_POR,PPV_GRUJ,PPV_NRP,PPV_RP,VNRP_NEISP," +
                 "VNRP_SPEC_TEX,DOR_SDACH_GOS,DOR_PRIEM_GOS,INDEX_POEZD,NOM_POEZD,NPP_VAG,NOM_PARK,NOM_PUT,KOL_ZPU,KOL_GRJ_KONT,KOL_POR_KONT,NOM_KON1,NOM_KON2,NOM_KON3,NOM_KON4,NOM_KON5,NOM_KON6,NOM_KON7," +
                 " NOM_KON8,NOM_KON9,NOM_KON10,NOM_KON11,NOM_KON12,NOM_KON13,ID_OTPRK,NOM_NAK,UNO,NOM_OTPRK_1,NOM_OTPRK_2,NOM_OTPRK_3,NOM_OTPRK_4,NOM_OTPRK_5,NOM_OTPRK_6,NOM_OTPRK_7,NOM_OTPRK_8,NOM_OTPRK_9," +
                 "NOM_OTPRK_10,NOM_OTPRK_11,NOM_OTPRK_12,NOM_OTPRK_13,ID_OTPRK_DOSYL,UNO_DOSYL,DATE_DOSTAV,RASST_OB,RASST_STAN_OP,RASST_STAN_NAZN,PROST_DN,PROST_СН,PROST_MIN,NORMA_KM, OSTATOK,KOD_GRZ_VYGR," +
                 "PR_OST_GRZ,DATE_OTPR,KOD_PL_OTPR,TARIF,OTM_GOD_VAG,POROG_PROB,PR_OTM,PR_STR,DATE_ZAP,KOD_GRZ_UCH,KDS_T,DVS_T,ID_GRUZPOL,ID_GRUZOTPR,SYSDATE," +
                 "(select name from complex.spr_wagon_type where ROD_VAG_UCH = complex.spr_wagon_type.rzd_id_sinhro) as NAIM_ROD_VAG, " +
                 "(select distinct st_name from SPR_ETRAN_station where ST_CODE = substr(STAN_NAZN, 0,(length(STAN_NAZN)-1)) group by st_name) as NAIM_STAN_NAZN, " +
                 "(select shortname from spr_etran_org where id=temp_dislokacia.id_gruzpol) as NAIM_GRUZPOL_OKPO, " +
                 "(select fr_name from SPR_ETRAN_FREIGHT where FR_CODE_ETSNG = substr(KOD_GRZ_UCH, 0, 5)) as NAIM_KOD_GRZ, " +
                 "(select distinct st_name from SPR_ETRAN_station where ST_CODE = substr(STAN_OP, 0,(length(STAN_OP)-1)) group by st_name) as NAIM_STAN_OP, " +
                 "(select naim from spr_collection where id_spr = 'oper_vag' and spr_collection.sv = kop_VMD) as NAIM_KOP_VMD,  " +
                 "(select shortname from spr_etran_org where id=temp_dislokacia.id_gruzotpr) as NAIM_GRUZOTPR_OKPO FROM TEMP_DISLOKACIA where  DATE_OP>(sysdate-10)";
                string ins_vag_kog = "INSERT INTO DISLOKACIA (NOM_VAG, ROD_VAG_UCH, KOD_SOB, DATE_NACH, STAN_NACH, DOR_NACH, STR_NACH, STAN_NAZN, DOR_NAZN, STR_NAZN, GRUZPOL, GRUZPOL_OKPO, GRUZOTPR," +
                     "GRUZOTPR_OKPO,KOD_GRZ_GNG,PROB_GRJ,PROB_POR,OS_OTM1,OS_OTM2,OS_OTM3,VES_GRZ,DATE_OP,DOR_RASCH,STAN_OP,KOP_VMD,KOP_PMD,PPV_MEST,PPV_TRANZ,PPV_POR,PPV_GRUJ,PPV_NRP,PPV_RP,VNRP_NEISP," +
                     "VNRP_SPEC_TEX,DOR_SDACH_GOS,DOR_PRIEM_GOS,INDEX_POEZD,NOM_POEZD,NPP_VAG,NOM_PARK,NOM_PUT,KOL_ZPU,KOL_GRJ_KONT,KOL_POR_KONT,NOM_KON1,NOM_KON2,NOM_KON3,NOM_KON4,NOM_KON5,NOM_KON6,NOM_KON7," +
                     " NOM_KON8,NOM_KON9,NOM_KON10,NOM_KON11,NOM_KON12,NOM_KON13,ID_OTPRK,NOM_NAK,UNO,NOM_OTPRK_1,NOM_OTPRK_2,NOM_OTPRK_3,NOM_OTPRK_4,NOM_OTPRK_5,NOM_OTPRK_6,NOM_OTPRK_7,NOM_OTPRK_8,NOM_OTPRK_9," +
                     "NOM_OTPRK_10,NOM_OTPRK_11,NOM_OTPRK_12,NOM_OTPRK_13,ID_OTPRK_DOSYL,UNO_DOSYL,DATE_DOSTAV,RASST_OB,RASST_STAN_OP,RASST_STAN_NAZN,PROST_DN,PROST_СН,PROST_MIN,NORMA_KM, OSTATOK,KOD_GRZ_VYGR," +
                     "PR_OST_GRZ,DATE_OTPR,KOD_PL_OTPR,TARIF,OTM_GOD_VAG,POROG_PROB,PR_OTM,PR_STR,DATE_ZAP,KOD_GRZ_UCH,KDS_T,DVS_T,ID_GRUZPOL,ID_GRUZOTPR,DATE_INS,NAIM_ROD_VAG,NAIM_STAN_NAZN,NAIM_GRUZPOL_OKPO,NAIM_KOD_GRZ, " +
                     "NAIM_STAN_OP,NAIM_KOP_VMD,NAIM_GRUZOTPR_OKPO) " +
                     "SELECT NOM_VAG, ROD_VAG_UCH, KOD_SOB, DATE_NACH, STAN_NACH, DOR_NACH, STR_NACH, STAN_NAZN, DOR_NAZN, STR_NAZN, GRUZPOL, GRUZPOL_OKPO, GRUZOTPR," +
                     "GRUZOTPR_OKPO,KOD_GRZ_GNG,PROB_GRJ,PROB_POR,OS_OTM1,OS_OTM2,OS_OTM3,VES_GRZ,DATE_OP,DOR_RASCH,STAN_OP,KOP_VMD,KOP_PMD,PPV_MEST,PPV_TRANZ,PPV_POR,PPV_GRUJ,PPV_NRP,PPV_RP,VNRP_NEISP," +
                     "VNRP_SPEC_TEX,DOR_SDACH_GOS,DOR_PRIEM_GOS,INDEX_POEZD,NOM_POEZD,NPP_VAG,NOM_PARK,NOM_PUT,KOL_ZPU,KOL_GRJ_KONT,KOL_POR_KONT,NOM_KON1,NOM_KON2,NOM_KON3,NOM_KON4,NOM_KON5,NOM_KON6,NOM_KON7," +
                     " NOM_KON8,NOM_KON9,NOM_KON10,NOM_KON11,NOM_KON12,NOM_KON13,ID_OTPRK,NOM_NAK,UNO,NOM_OTPRK_1,NOM_OTPRK_2,NOM_OTPRK_3,NOM_OTPRK_4,NOM_OTPRK_5,NOM_OTPRK_6,NOM_OTPRK_7,NOM_OTPRK_8,NOM_OTPRK_9," +
                     "NOM_OTPRK_10,NOM_OTPRK_11,NOM_OTPRK_12,NOM_OTPRK_13,ID_OTPRK_DOSYL,UNO_DOSYL,DATE_DOSTAV,RASST_OB,RASST_STAN_OP,RASST_STAN_NAZN,PROST_DN,PROST_СН,PROST_MIN,NORMA_KM, OSTATOK,KOD_GRZ_VYGR," +
                     "PR_OST_GRZ,DATE_OTPR,KOD_PL_OTPR,TARIF,OTM_GOD_VAG,POROG_PROB,PR_OTM,PR_STR,DATE_ZAP,KOD_GRZ_UCH,KDS_T,DVS_T,ID_GRUZPOL,ID_GRUZOTPR,SYSDATE," +
                     "(select name from complex.spr_wagon_type where ROD_VAG_UCH = complex.spr_wagon_type.rzd_id_sinhro) as NAIM_ROD_VAG, " +
                     "(select distinct st_name from SPR_ETRAN_station where ST_CODE = substr(STAN_NAZN, 0,(length(STAN_NAZN)-1)) group by st_name) as NAIM_STAN_NAZN, " +
                     "(select shortname from spr_etran_org where id=temp_dislokacia.id_gruzpol) as NAIM_GRUZPOL_OKPO, " +
                     "(select fr_name from SPR_ETRAN_FREIGHT where FR_CODE_ETSNG = substr(KOD_GRZ_UCH, 0, 5)) as NAIM_KOD_GRZ, " +
                     "(select distinct st_name from SPR_ETRAN_station where ST_CODE = substr(STAN_OP, 0, (length(STAN_OP)-1)) group by st_name) as NAIM_STAN_OP, " +
                     "(select naim from spr_collection where id_spr = 'oper_vag' and spr_collection.sv = kop_VMD) as NAIM_KOP_VMD," +
                     "(select shortname from spr_etran_org where id=temp_dislokacia.id_gruzotpr) as NAIM_GRUZOTPR_OKPO FROM TEMP_DISLOKACIA2 where nom_vag not in (select nom_vag from dislokacia)";
                string dl_v_k = "DELETE FROM SPR_COLLECTION WHERE ID_SPR in ('VAG_KOG','VAG_PPGT')";
                string ins_spr_kog = "insert into spr_collection(id_spr,NAIM) select 'VAG_KOG',nom_vag from temp_dislokacia2 where sobs=95682893";
                string ins_spr_ppgt = "insert into spr_collection(id_spr,NAIM) select 'VAG_PPGT',nom_vag from temp_dislokacia2 where sobs=05141354";
                string check_ins = "insert into DISLOKACIA_CHECK(NOM_vag,ID_OTPRK,NOM_NAK,UNO,data) select NOM_vag, ID_OTPRK, NOM_NAK, UNO, sysdate from dislokacia where " +
                                  " not EXISTS(select nom_vag  from dislokacia_check where dislokacia.nom_vag = dislokacia_check.NOM_VAG)";
                string check_del = "delete from DISLOKACIA_CHECK where not EXISTS (select nom_vag  from dislokacia where dislokacia.nom_vag=dislokacia_check.NOM_VAG)";
                string check_update = "update DISLOKACIA_CHECK set complex=1 where EXISTS(select wagon_id from complex.prsd_wagon_oper where " +
                    "complex.prsd_wagon_oper.wagon_id= DISLOKACIA_CHECK.nom_vag and is_del = 0 and date_close is null  and wagon_id is not null) and complex is null";
                string log_dislo = "insert into spr_etran_log (spr,cikl,DATA,col_z) select 'dislokacia' as id_st,'1' as cikl,sysdate as data,count(*) as col_z from dislokacia";
                string ins_dislokacia_history = "INSERT INTO DISLOKACIA_HISTORY (NOM_VAG, ROD_VAG_UCH, KOD_SOB, DATE_NACH, STAN_NACH, DOR_NACH, STR_NACH, STAN_NAZN, DOR_NAZN, STR_NAZN, GRUZPOL, GRUZPOL_OKPO, GRUZOTPR," +
                    " GRUZOTPR_OKPO,KOD_GRZ_GNG,PROB_GRJ,PROB_POR,OS_OTM1,OS_OTM2,OS_OTM3,VES_GRZ,DATE_OP,DOR_RASCH,STAN_OP,KOP_VMD,KOP_PMD,PPV_MEST,PPV_TRANZ,PPV_POR,PPV_GRUJ,PPV_NRP,PPV_RP,VNRP_NEISP, " +
                    " VNRP_SPEC_TEX,DOR_SDACH_GOS,DOR_PRIEM_GOS,INDEX_POEZD,NOM_POEZD,NPP_VAG,NOM_PARK,NOM_PUT,KOL_ZPU,KOL_GRJ_KONT,KOL_POR_KONT,NOM_KON1,NOM_KON2,NOM_KON3,NOM_KON4,NOM_KON5,NOM_KON6,NOM_KON7," +
                    " NOM_KON8,NOM_KON9,NOM_KON10,NOM_KON11,NOM_KON12,NOM_KON13,ID_OTPRK,NOM_NAK,UNO,NOM_OTPRK_1,NOM_OTPRK_2,NOM_OTPRK_3,NOM_OTPRK_4,NOM_OTPRK_5,NOM_OTPRK_6,NOM_OTPRK_7,NOM_OTPRK_8,NOM_OTPRK_9," +
                    " NOM_OTPRK_10,NOM_OTPRK_11,NOM_OTPRK_12,NOM_OTPRK_13,ID_OTPRK_DOSYL,UNO_DOSYL,DATE_DOSTAV,RASST_OB,RASST_STAN_OP,RASST_STAN_NAZN,PROST_DN,PROST_СН,PROST_MIN,NORMA_KM, OSTATOK,KOD_GRZ_VYGR," +
                    " PR_OST_GRZ,DATE_OTPR,KOD_PL_OTPR,TARIF,OTM_GOD_VAG,POROG_PROB,PR_OTM,PR_STR,DATE_ZAP,KOD_GRZ_UCH,KDS_T,DVS_T,ID_GRUZPOL,ID_GRUZOTPR,DATE_INS,NAIM_ROD_VAG,NAIM_STAN_NAZN,NAIM_GRUZPOL_OKPO,NAIM_KOD_GRZ, " +
                    " NAIM_STAN_OP,NAIM_KOP_VMD,NAIM_GRUZOTPR_OKPO)" +
                    " select NOM_VAG, ROD_VAG_UCH, KOD_SOB, DATE_NACH, STAN_NACH, DOR_NACH, STR_NACH, STAN_NAZN, DOR_NAZN, STR_NAZN, GRUZPOL, GRUZPOL_OKPO, GRUZOTPR," +
                    " GRUZOTPR_OKPO, KOD_GRZ_GNG, PROB_GRJ, PROB_POR, OS_OTM1, OS_OTM2, OS_OTM3, VES_GRZ, DATE_OP, DOR_RASCH, STAN_OP, KOP_VMD, KOP_PMD, PPV_MEST, PPV_TRANZ, PPV_POR, PPV_GRUJ, PPV_NRP, PPV_RP, VNRP_NEISP," +
                    " VNRP_SPEC_TEX, DOR_SDACH_GOS, DOR_PRIEM_GOS, INDEX_POEZD, NOM_POEZD, NPP_VAG, NOM_PARK, NOM_PUT, KOL_ZPU, KOL_GRJ_KONT, KOL_POR_KONT, NOM_KON1, NOM_KON2, NOM_KON3, NOM_KON4, NOM_KON5, NOM_KON6, NOM_KON7," +
                    " NOM_KON8, NOM_KON9, NOM_KON10, NOM_KON11, NOM_KON12, NOM_KON13, ID_OTPRK, NOM_NAK, UNO, NOM_OTPRK_1, NOM_OTPRK_2, NOM_OTPRK_3, NOM_OTPRK_4, NOM_OTPRK_5, NOM_OTPRK_6, NOM_OTPRK_7, NOM_OTPRK_8, NOM_OTPRK_9," +
                    " NOM_OTPRK_10, NOM_OTPRK_11, NOM_OTPRK_12, NOM_OTPRK_13, ID_OTPRK_DOSYL, UNO_DOSYL, DATE_DOSTAV, RASST_OB, RASST_STAN_OP, RASST_STAN_NAZN, PROST_DN, PROST_СН, PROST_MIN, NORMA_KM, OSTATOK, KOD_GRZ_VYGR," +
                    " PR_OST_GRZ, DATE_OTPR, KOD_PL_OTPR, TARIF, OTM_GOD_VAG, POROG_PROB, PR_OTM, PR_STR, DATE_ZAP, KOD_GRZ_UCH, KDS_T, DVS_T, ID_GRUZPOL, ID_GRUZOTPR, DATE_INS, NAIM_ROD_VAG, NAIM_STAN_NAZN, NAIM_GRUZPOL_OKPO, NAIM_KOD_GRZ," +
                    " NAIM_STAN_OP, NAIM_KOP_VMD, NAIM_GRUZOTPR_OKPO from DISLOKACIA";
               /* sq.Oracle_v1(del_dis);
                sq.Oracle_v1(ins_dis);                
                sq.Oracle_v1(ins_vag_kog);
                sq.Oracle_v1(dl_v_k);
                sq.Oracle_v1(ins_spr_kog);
                sq.Oracle_v1(ins_spr_ppgt);
                sq.Oracle_v1(check_ins);
                sq.Oracle_v1(check_del);
                sq.Oracle_v1(check_update);
                sq.Oracle_v1(log_dislo);
                sq.Oracle_v1(ins_dislokacia_history);*/
              


                  using (OracleConnection conn2 = new OracleConnection("Data Source = flagman; Persist Security Info=True;User ID = vsptsvod; Password=sibpromtrans;Unicode=True"))
                  {
                      OracleCommand command1 = new OracleCommand(del_dis, conn2);
                      //    OracleCommand command11 = new OracleCommand(del_dis_sobs, conn2);
                      OracleCommand command2 = new OracleCommand(ins_dis, conn2);
                      OracleCommand command3 = new OracleCommand(ins_vag_kog, conn2);

                      conn2.Open();
                      OracleDataReader ud1 = command1.ExecuteReader();
                      // OracleDataReader ud2 = command11.ExecuteReader();
                      conn2.Close();

                      conn2.Open();
                      OracleDataReader ins_dislok = command2.ExecuteReader();
                      conn2.Close();

                      conn2.Open();
                      OracleDataReader ins_KOG = command3.ExecuteReader();
                      conn2.Close();

                  }
                using (OracleConnection conn3 = new OracleConnection("Data Source = flagman; Persist Security Info=True;User ID = vsptsvod; Password=sibpromtrans;Unicode=True"))
                {
                    OracleCommand command4 = new OracleCommand(dl_v_k, conn3);
                    OracleCommand command5 = new OracleCommand(ins_spr_kog, conn3);
                    OracleCommand command6 = new OracleCommand(ins_spr_ppgt, conn3);
                    OracleCommand command7 = new OracleCommand(check_ins, conn3);
                    OracleCommand command8 = new OracleCommand(check_del, conn3);
                    OracleCommand command9 = new OracleCommand(check_update, conn3);
                    OracleCommand command10 = new OracleCommand(log_dislo, conn3);
                    OracleCommand command11 = new OracleCommand(ins_dislokacia_history, conn3);

                    conn3.Open();
                    OracleDataReader dd = command4.ExecuteReader();
                    conn3.Close();
                    conn3.Open();
                    OracleDataReader insvkog = command5.ExecuteReader();
                    conn3.Close();
                    conn3.Open();
                    OracleDataReader insvppgt = command6.ExecuteReader();
                    conn3.Close();
                    conn3.Open();
                    OracleDataReader ch_ins = command7.ExecuteReader();
                    conn3.Close();
                    conn3.Open();
                    OracleDataReader ch_del = command8.ExecuteReader();
                    conn3.Close();
                    conn3.Open();
                    OracleDataReader ch_up = command9.ExecuteReader();
                    conn3.Close();
                    conn3.Open();
                    OracleDataReader log = command10.ExecuteReader();
                    OracleDataReader ins_d_h = command11.ExecuteReader();
                    conn3.Close();
                }
                string del_dislokacia_ms = "delete from [dbo].[Dislokacia]";
                string ins_dislokacia_ms = "INSERT INTO[dbo].[Dislokacia]([NOM_VAG],[ROD_VAG_UCH],[KOD_SOB],[DATE_NACH]" +
                    ",[STAN_NACH],[DOR_NACH],[STR_NACH],[DATE_KON],[STAN_NAZN],[DOR_NAZN],[STR_NAZN],[GRUZPOL],[NOM_PARK],[NOM_PUT],[KOL_ZPU],[KOL_GRJ_KONT],[KOL_POR_KONT],[NOM_KON1],[NOM_KON2]," +
                    "[NOM_KON3],[NOM_KON4],[NOM_KON5],[NOM_KON6],[NOM_KON7],[NOM_KON8],[NOM_KON9],[NOM_KON10],[NOM_KON11],[NOM_KON12],[NOM_KON13],[ID_OTPRK],[NOM_NAK],[UNO],[NOM_OTPRK_1],[NOM_OTPRK_2]," +
                    "[NOM_OTPRK_3],[NOM_OTPRK_4],[NOM_OTPRK_5],[NOM_OTPRK_6],[NOM_OTPRK_7],[NOM_OTPRK_8],[NOM_OTPRK_9],[NOM_OTPRK_10],[NOM_OTPRK_11],[NOM_OTPRK_12],[NOM_OTPRK_13],[ID_OTPRK_DOSYL]," +
                    "[UNO_DOSYL],[DATE_DOSTAV],[RASST_OB],[RASST_STAN_OP],[RASST_STAN_NAZN],[PROST_DN],[PROST_СН],[PROST_MIN],[NORMA_KM],[OSTATOK],[KOD_GRZ_VYGR],[PR_OST_GRZ],[DATE_OTPR],[DATE_PRIB]," +
                    "[KOD_PL_OTPR],[TARIF],[OTM_GOD_VAG],[POROG_PROB],[PR_OTM],[PR_STR],[DATE_ZAP],[KOD_GRZ_UCH],[KDS_T],[DVS_T],[ID_GRUZPOL],[ID_GRUZOTPR],[GRUZPOL_OKPO],[GRUZOTPR],[GRUZOTPR_OKPO]," +
                    "[KOD_GRZ_GNG],[PROB_GRJ],[PROB_POR],[OS_OTM1],[OS_OTM2],[OS_OTM3],[VES_GRZ],[DATE_OP],[DOR_RASCH],[STAN_OP],[KOP_VMD],[KOP_PMD],[PPV_MEST],[PPV_TRANZ],[PPV_POR],[PPV_GRUJ],[PPV_NRP]," +
                    "[PPV_RP],[VNRP_NEISP],[VNRP_SPEC_TEX],[DOR_SDACH_GOS],[DOR_PRIEM_GOS],[INDEX_POEZD],[NOM_POEZD],[NPP_VAG],[DATE_INS],[NAIM_ROD_VAG],[NAIM_STAN_NAZN],[NAIM_GRUZPOL_OKPO],[NAIM_KOD_GRZ]," +
                    "[NAIM_STAN_OP],[NAIM_KOP_VMD],[NAIM_GRUZOTPR_OKPO])" +
                    "(SELECT[NOM_VAG],[ROD_VAG_UCH],[KOD_SOB],[DATE_NACH],[STAN_NACH],[DOR_NACH],[STR_NACH],[DATE_KON],[STAN_NAZN],[DOR_NAZN],[STR_NAZN],[GRUZPOL],[NOM_PARK],[NOM_PUT],[KOL_ZPU],[KOL_GRJ_KONT]" +
                    ",[KOL_POR_KONT],[NOM_KON1],[NOM_KON2],[NOM_KON3],[NOM_KON4],[NOM_KON5],[NOM_KON6],[NOM_KON7],[NOM_KON8],[NOM_KON9],[NOM_KON10],[NOM_KON11],[NOM_KON12],[NOM_KON13],[ID_OTPRK],[NOM_NAK],[UNO]," +
                    "[NOM_OTPRK_1],[NOM_OTPRK_2],[NOM_OTPRK_3],[NOM_OTPRK_4],[NOM_OTPRK_5],[NOM_OTPRK_6],[NOM_OTPRK_7],[NOM_OTPRK_8],[NOM_OTPRK_9],[NOM_OTPRK_10],[NOM_OTPRK_11],[NOM_OTPRK_12],[NOM_OTPRK_13]," +
                    "[ID_OTPRK_DOSYL],[UNO_DOSYL],[DATE_DOSTAV],[RASST_OB],[RASST_STAN_OP],[RASST_STAN_NAZN],[PROST_DN],[PROST_СН],[PROST_MIN],[NORMA_KM],[OSTATOK],[KOD_GRZ_VYGR],[PR_OST_GRZ],[DATE_OTPR]," +
                    "[DATE_PRIB],[KOD_PL_OTPR],[TARIF],[OTM_GOD_VAG],[POROG_PROB],[PR_OTM],[PR_STR],[DATE_ZAP],[KOD_GRZ_UCH],[KDS_T],[DVS_T],[ID_GRUZPOL],[ID_GRUZOTPR],[GRUZPOL_OKPO],[GRUZOTPR],[GRUZOTPR_OKPO]," +
                    "[KOD_GRZ_GNG],[PROB_GRJ],[PROB_POR],[OS_OTM1],[OS_OTM2],[OS_OTM3],[VES_GRZ],[DATE_OP],[DOR_RASCH],[STAN_OP],[KOP_VMD],[KOP_PMD],[PPV_MEST],[PPV_TRANZ],[PPV_POR],[PPV_GRUJ],[PPV_NRP]," +
                    "[PPV_RP],[VNRP_NEISP],[VNRP_SPEC_TEX],[DOR_SDACH_GOS],[DOR_PRIEM_GOS],[INDEX_POEZD],[NOM_POEZD],[NPP_VAG],[DATE_INS],[NAIM_ROD_VAG],[NAIM_STAN_NAZN],[NAIM_GRUZPOL_OKPO],[NAIM_KOD_GRZ]," +
                   "[NAIM_STAN_OP],[NAIM_KOP_VMD],[NAIM_GRUZOTPR_OKPO] FROM[FLAGMAN]..[VSPTSVOD].[DISLOKACIA])";
                  sq.Mssql_v(del_dislokacia_ms);
                  sq.Mssql_v(ins_dislokacia_ms);


               /* using (SqlConnection conn_ms = new SqlConnection("Data Source=192.168.1.13;Initial Catalog=dislokacia;User ID=Roman;Password=238533"))
                {

                    SqlCommand command1 = new SqlCommand(del_dislokacia_ms, conn_ms);
                    SqlCommand command2 = new SqlCommand(ins_dislokacia_ms, conn_ms);
                    conn_ms.Open();

                    SqlDataReader thisdel = command1.ExecuteReader();
                    conn_ms.Close();
                    conn_ms.Open();
                    SqlDataReader thisins = command2.ExecuteReader();
                    conn_ms.Close();
                }


    */
            }
            else
            {
                // Console.WriteLine("Исключение!");
                string address = "roman@abakan.vspt.ru";
                string TextPisma = "Нет данных в TEMP_DISLOKACIA!!!";
                EmOpov pi = new EmOpov();
                string Zagolovok = "Ошибка вставки в таблицу Dilokacia";
                pi.Opov_err(address, TextPisma, Zagolovok);
                //continue;
            }
        }
        }
    }



                    
            

