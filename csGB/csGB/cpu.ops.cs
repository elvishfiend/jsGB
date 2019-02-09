using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB
{
    public static partial class cpu
    {
        public static class _ops
        {
            /*--- Load/store ---*/
            public static void LDrr_bb() { cpu._r.b = cpu._r.b; cpu._r.m = 1; }
            public static void LDrr_bc() { cpu._r.b = cpu._r.c; cpu._r.m = 1; }
            public static void LDrr_bd() { cpu._r.b = cpu._r.d; cpu._r.m = 1; }
            public static void LDrr_be() { cpu._r.b = cpu._r.e; cpu._r.m = 1; }
            public static void LDrr_bh() { cpu._r.b = cpu._r.h; cpu._r.m = 1; }
            public static void LDrr_bl() { cpu._r.b = cpu._r.l; cpu._r.m = 1; }
            public static void LDrr_ba() { cpu._r.b = cpu._r.a; cpu._r.m = 1; }
            public static void LDrr_cb() { cpu._r.c = cpu._r.b; cpu._r.m = 1; }
            public static void LDrr_cc() { cpu._r.c = cpu._r.c; cpu._r.m = 1; }
            public static void LDrr_cd() { cpu._r.c = cpu._r.d; cpu._r.m = 1; }
            public static void LDrr_ce() { cpu._r.c = cpu._r.e; cpu._r.m = 1; }
            public static void LDrr_ch() { cpu._r.c = cpu._r.h; cpu._r.m = 1; }
            public static void LDrr_cl() { cpu._r.c = cpu._r.l; cpu._r.m = 1; }
            public static void LDrr_ca() { cpu._r.c = cpu._r.a; cpu._r.m = 1; }
            public static void LDrr_db() { cpu._r.d = cpu._r.b; cpu._r.m = 1; }
            public static void LDrr_dc() { cpu._r.d = cpu._r.c; cpu._r.m = 1; }
            public static void LDrr_dd() { cpu._r.d = cpu._r.d; cpu._r.m = 1; }
            public static void LDrr_de() { cpu._r.d = cpu._r.e; cpu._r.m = 1; }
            public static void LDrr_dh() { cpu._r.d = cpu._r.h; cpu._r.m = 1; }
            public static void LDrr_dl() { cpu._r.d = cpu._r.l; cpu._r.m = 1; }
            public static void LDrr_da() { cpu._r.d = cpu._r.a; cpu._r.m = 1; }
            public static void LDrr_eb() { cpu._r.e = cpu._r.b; cpu._r.m = 1; }
            public static void LDrr_ec() { cpu._r.e = cpu._r.c; cpu._r.m = 1; }
            public static void LDrr_ed() { cpu._r.e = cpu._r.d; cpu._r.m = 1; }
            public static void LDrr_ee() { cpu._r.e = cpu._r.e; cpu._r.m = 1; }
            public static void LDrr_eh() { cpu._r.e = cpu._r.h; cpu._r.m = 1; }
            public static void LDrr_el() { cpu._r.e = cpu._r.l; cpu._r.m = 1; }
            public static void LDrr_ea() { cpu._r.e = cpu._r.a; cpu._r.m = 1; }
            public static void LDrr_hb() { cpu._r.h = cpu._r.b; cpu._r.m = 1; }
            public static void LDrr_hc() { cpu._r.h = cpu._r.c; cpu._r.m = 1; }
            public static void LDrr_hd() { cpu._r.h = cpu._r.d; cpu._r.m = 1; }
            public static void LDrr_he() { cpu._r.h = cpu._r.e; cpu._r.m = 1; }
            public static void LDrr_hh() { cpu._r.h = cpu._r.h; cpu._r.m = 1; }
            public static void LDrr_hl() { cpu._r.h = cpu._r.l; cpu._r.m = 1; }
            public static void LDrr_ha() { cpu._r.h = cpu._r.a; cpu._r.m = 1; }
            public static void LDrr_lb() { cpu._r.l = cpu._r.b; cpu._r.m = 1; }
            public static void LDrr_lc() { cpu._r.l = cpu._r.c; cpu._r.m = 1; }
            public static void LDrr_ld() { cpu._r.l = cpu._r.d; cpu._r.m = 1; }
            public static void LDrr_le() { cpu._r.l = cpu._r.e; cpu._r.m = 1; }
            public static void LDrr_lh() { cpu._r.l = cpu._r.h; cpu._r.m = 1; }
            public static void LDrr_ll() { cpu._r.l = cpu._r.l; cpu._r.m = 1; }
            public static void LDrr_la() { cpu._r.l = cpu._r.a; cpu._r.m = 1; }
            public static void LDrr_ab() { cpu._r.a = cpu._r.b; cpu._r.m = 1; }
            public static void LDrr_ac() { cpu._r.a = cpu._r.c; cpu._r.m = 1; }
            public static void LDrr_ad() { cpu._r.a = cpu._r.d; cpu._r.m = 1; }
            public static void LDrr_ae() { cpu._r.a = cpu._r.e; cpu._r.m = 1; }
            public static void LDrr_ah() { cpu._r.a = cpu._r.h; cpu._r.m = 1; }
            public static void LDrr_al() { cpu._r.a = cpu._r.l; cpu._r.m = 1; }
            public static void LDrr_aa() { cpu._r.a = cpu._r.a; cpu._r.m = 1; }

            public static void LDrHLm_b() { cpu._r.b = MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.m = 2; }
            public static void LDrHLm_c() { cpu._r.c = MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.m = 2; }
            public static void LDrHLm_d() { cpu._r.d = MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.m = 2; }
            public static void LDrHLm_e() { cpu._r.e = MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.m = 2; }
            public static void LDrHLm_h() { cpu._r.h = MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.m = 2; }
            public static void LDrHLm_l() { cpu._r.l = MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.m = 2; }
            public static void LDrHLm_a() { cpu._r.a = MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.m = 2; }

            public static void LDHLmr_b() { MMU.wb((cpu._r.h << 8) + cpu._r.l, cpu._r.b); cpu._r.m = 2; }
            public static void LDHLmr_c() { MMU.wb((cpu._r.h << 8) + cpu._r.l, cpu._r.c); cpu._r.m = 2; }
            public static void LDHLmr_d() { MMU.wb((cpu._r.h << 8) + cpu._r.l, cpu._r.d); cpu._r.m = 2; }
            public static void LDHLmr_e() { MMU.wb((cpu._r.h << 8) + cpu._r.l, cpu._r.e); cpu._r.m = 2; }
            public static void LDHLmr_h() { MMU.wb((cpu._r.h << 8) + cpu._r.l, cpu._r.h); cpu._r.m = 2; }
            public static void LDHLmr_l() { MMU.wb((cpu._r.h << 8) + cpu._r.l, cpu._r.l); cpu._r.m = 2; }
            public static void LDHLmr_a() { MMU.wb((cpu._r.h << 8) + cpu._r.l, cpu._r.a); cpu._r.m = 2; }

            public static void LDrn_b() { cpu._r.b = MMU.rb(cpu._r.pc); cpu._r.pc++; cpu._r.m = 2; }
            public static void LDrn_c() { cpu._r.c = MMU.rb(cpu._r.pc); cpu._r.pc++; cpu._r.m = 2; }
            public static void LDrn_d() { cpu._r.d = MMU.rb(cpu._r.pc); cpu._r.pc++; cpu._r.m = 2; }
            public static void LDrn_e() { cpu._r.e = MMU.rb(cpu._r.pc); cpu._r.pc++; cpu._r.m = 2; }
            public static void LDrn_h() { cpu._r.h = MMU.rb(cpu._r.pc); cpu._r.pc++; cpu._r.m = 2; }
            public static void LDrn_l() { cpu._r.l = MMU.rb(cpu._r.pc); cpu._r.pc++; cpu._r.m = 2; }
            public static void LDrn_a() { cpu._r.a = MMU.rb(cpu._r.pc); cpu._r.pc++; cpu._r.m = 2; }

            public static void LDHLmn() { MMU.wb((cpu._r.h << 8) + cpu._r.l, MMU.rb(cpu._r.pc)); cpu._r.pc++; cpu._r.m = 3; }

            public static void LDBCmA() { MMU.wb((cpu._r.b << 8) + cpu._r.c, cpu._r.a); cpu._r.m = 2; }
            public static void LDDEmA() { MMU.wb((cpu._r.d << 8) + cpu._r.e, cpu._r.a); cpu._r.m = 2; }

            public static void LDmmA() { MMU.wb(MMU.rw(cpu._r.pc), cpu._r.a); cpu._r.pc += 2; cpu._r.m = 4; }

            public static void LDABCm() { cpu._r.a = MMU.rb((cpu._r.b << 8) + cpu._r.c); cpu._r.m = 2; }
            public static void LDADEm() { cpu._r.a = MMU.rb((cpu._r.d << 8) + cpu._r.e); cpu._r.m = 2; }

            public static void LDAmm() { cpu._r.a = MMU.rb(MMU.rw(cpu._r.pc)); cpu._r.pc += 2; cpu._r.m = 4; }

            public static void LDBCnn() { cpu._r.c = MMU.rb(cpu._r.pc); cpu._r.b = MMU.rb(cpu._r.pc + 1); cpu._r.pc += 2; cpu._r.m = 3; }
            public static void LDDEnn() { cpu._r.e = MMU.rb(cpu._r.pc); cpu._r.d = MMU.rb(cpu._r.pc + 1); cpu._r.pc += 2; cpu._r.m = 3; }
            public static void LDHLnn() { cpu._r.l = MMU.rb(cpu._r.pc); cpu._r.h = MMU.rb(cpu._r.pc + 1); cpu._r.pc += 2; cpu._r.m = 3; }
            public static void LDSPnn() { cpu._r.sp = MMU.rw(cpu._r.pc); cpu._r.pc += 2; cpu._r.m = 3; }

            public static void LDHLmm() { var i = MMU.rw(cpu._r.pc); cpu._r.pc += 2; cpu._r.l = MMU.rb(i); cpu._r.h = MMU.rb(i + 1); cpu._r.m = 5; }
            public static void LDmmHL() { var i = MMU.rw(cpu._r.pc); cpu._r.pc += 2; MMU.ww(i, (cpu._r.h << 8) + cpu._r.l); cpu._r.m = 5; }

            public static void LDHLIA() { MMU.wb((cpu._r.h << 8) + cpu._r.l, cpu._r.a); cpu._r.l = (cpu._r.l + 1) & 255; if (cpu._r.l == 0) cpu._r.h = (cpu._r.h + 1) & 255; cpu._r.m = 2; }
            public static void LDAHLI() { cpu._r.a = MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.l = (cpu._r.l + 1) & 255; if (cpu._r.l == 0) cpu._r.h = (cpu._r.h + 1) & 255; cpu._r.m = 2; }

            public static void LDHLDA() { MMU.wb((cpu._r.h << 8) + cpu._r.l, cpu._r.a); cpu._r.l = (cpu._r.l - 1) & 255; if (cpu._r.l == 255) cpu._r.h = (cpu._r.h - 1) & 255; cpu._r.m = 2; }
            public static void LDAHLD() { cpu._r.a = MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.l = (cpu._r.l - 1) & 255; if (cpu._r.l == 255) cpu._r.h = (cpu._r.h - 1) & 255; cpu._r.m = 2; }

            public static void LDAIOn() { cpu._r.a = MMU.rb(0xFF00 + MMU.rb(cpu._r.pc)); cpu._r.pc++; cpu._r.m = 3; }
            public static void LDIOnA() { MMU.wb(0xFF00 + MMU.rb(cpu._r.pc), cpu._r.a); cpu._r.pc++; cpu._r.m = 3; }
            public static void LDAIOC() { cpu._r.a = MMU.rb(0xFF00 + cpu._r.c); cpu._r.m = 2; }
            public static void LDIOCA() { MMU.wb(0xFF00 + cpu._r.c, cpu._r.a); cpu._r.m = 2; }

            public static void LDHLSPn() { var i = MMU.rb(cpu._r.pc); if (i > 127) i = -((~i + 1) & 255); cpu._r.pc++; i += cpu._r.sp; cpu._r.h = (i >> 8) & 255; cpu._r.l = i & 255; cpu._r.m = 3; }

            public static void SWAPr_b() { var tr = cpu._r.b; cpu._r.b = ((tr & 0xF) << 4) | ((tr & 0xF0) >> 4); cpu._r.f = cpu._r.b != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void SWAPr_c() { var tr = cpu._r.c; cpu._r.c = ((tr & 0xF) << 4) | ((tr & 0xF0) >> 4); cpu._r.f = cpu._r.c != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void SWAPr_d() { var tr = cpu._r.d; cpu._r.d = ((tr & 0xF) << 4) | ((tr & 0xF0) >> 4); cpu._r.f = cpu._r.d != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void SWAPr_e() { var tr = cpu._r.e; cpu._r.e = ((tr & 0xF) << 4) | ((tr & 0xF0) >> 4); cpu._r.f = cpu._r.e != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void SWAPr_h() { var tr = cpu._r.h; cpu._r.h = ((tr & 0xF) << 4) | ((tr & 0xF0) >> 4); cpu._r.f = cpu._r.h != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void SWAPr_l() { var tr = cpu._r.l; cpu._r.l = ((tr & 0xF) << 4) | ((tr & 0xF0) >> 4); cpu._r.f = cpu._r.l != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void SWAPr_a() { var tr = cpu._r.a; cpu._r.a = ((tr & 0xF) << 4) | ((tr & 0xF0) >> 4); cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }

            /*--- Data processing ---*/
            public static void ADDr_b() { var a = cpu._r.a; cpu._r.a += cpu._r.b; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.b ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void ADDr_c() { var a = cpu._r.a; cpu._r.a += cpu._r.c; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.c ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void ADDr_d() { var a = cpu._r.a; cpu._r.a += cpu._r.d; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.d ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void ADDr_e() { var a = cpu._r.a; cpu._r.a += cpu._r.e; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.e ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void ADDr_h() { var a = cpu._r.a; cpu._r.a += cpu._r.h; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.h ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void ADDr_l() { var a = cpu._r.a; cpu._r.a += cpu._r.l; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.l ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void ADDr_a() { var a = cpu._r.a; cpu._r.a += cpu._r.a; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.a ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void ADDHL() { var a = cpu._r.a; var m = MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.a += m; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ a ^ m) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 2; }
            public static void ADDn() { var a = cpu._r.a; var m = MMU.rb(cpu._r.pc); cpu._r.a += m; cpu._r.pc++; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ a ^ m) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 2; }
            public static void ADDHLBC() { var hl = (cpu._r.h << 8) + cpu._r.l; hl += (cpu._r.b << 8) + cpu._r.c; if (hl > 65535) cpu._r.f |= 0x10; else cpu._r.f &= 0xEF; cpu._r.h = (hl >> 8) & 255; cpu._r.l = hl & 255; cpu._r.m = 3; }
            public static void ADDHLDE() { var hl = (cpu._r.h << 8) + cpu._r.l; hl += (cpu._r.d << 8) + cpu._r.e; if (hl > 65535) cpu._r.f |= 0x10; else cpu._r.f &= 0xEF; cpu._r.h = (hl >> 8) & 255; cpu._r.l = hl & 255; cpu._r.m = 3; }
            public static void ADDHLHL() { var hl = (cpu._r.h << 8) + cpu._r.l; hl += (cpu._r.h << 8) + cpu._r.l; if (hl > 65535) cpu._r.f |= 0x10; else cpu._r.f &= 0xEF; cpu._r.h = (hl >> 8) & 255; cpu._r.l = hl & 255; cpu._r.m = 3; }
            public static void ADDHLSP() { var hl = (cpu._r.h << 8) + cpu._r.l; hl += cpu._r.sp; if (hl > 65535) cpu._r.f |= 0x10; else cpu._r.f &= 0xEF; cpu._r.h = (hl >> 8) & 255; cpu._r.l = hl & 255; cpu._r.m = 3; }
            public static void ADDSPn() { var i = MMU.rb(cpu._r.pc); if (i > 127) i = -((~i + 1) & 255); cpu._r.pc++; cpu._r.sp += i; cpu._r.m = 4; }

            public static void ADCr_b() { var a = cpu._r.a; cpu._r.a += cpu._r.b; cpu._r.a += ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.b ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void ADCr_c() { var a = cpu._r.a; cpu._r.a += cpu._r.c; cpu._r.a += ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.c ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void ADCr_d() { var a = cpu._r.a; cpu._r.a += cpu._r.d; cpu._r.a += ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.d ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void ADCr_e() { var a = cpu._r.a; cpu._r.a += cpu._r.e; cpu._r.a += ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.e ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void ADCr_h() { var a = cpu._r.a; cpu._r.a += cpu._r.h; cpu._r.a += ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.h ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void ADCr_l() { var a = cpu._r.a; cpu._r.a += cpu._r.l; cpu._r.a += ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.l ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void ADCr_a() { var a = cpu._r.a; cpu._r.a += cpu._r.a; cpu._r.a += ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.a ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void ADCHL() { var a = cpu._r.a; var m = MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.a += m; cpu._r.a += ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ m ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 2; }
            public static void ADCn() { var a = cpu._r.a; var m = MMU.rb(cpu._r.pc); cpu._r.a += m; cpu._r.pc++; cpu._r.a += ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a > 255) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ m ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 2; }

            public static void SUBr_b() { var a = cpu._r.a; cpu._r.a -= cpu._r.b; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.b ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void SUBr_c() { var a = cpu._r.a; cpu._r.a -= cpu._r.c; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.c ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void SUBr_d() { var a = cpu._r.a; cpu._r.a -= cpu._r.d; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.d ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void SUBr_e() { var a = cpu._r.a; cpu._r.a -= cpu._r.e; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.e ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void SUBr_h() { var a = cpu._r.a; cpu._r.a -= cpu._r.h; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.h ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void SUBr_l() { var a = cpu._r.a; cpu._r.a -= cpu._r.l; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.l ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void SUBr_a() { var a = cpu._r.a; cpu._r.a -= cpu._r.a; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.a ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void SUBHL() { var a = cpu._r.a; var m = MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.a -= m; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ m ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 2; }
            public static void SUBn() { var a = cpu._r.a; var m = MMU.rb(cpu._r.pc); cpu._r.a -= m; cpu._r.pc++; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ m ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 2; }

            public static void SBCr_b() { var a = cpu._r.a; cpu._r.a -= cpu._r.b; cpu._r.a -= ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.b ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void SBCr_c() { var a = cpu._r.a; cpu._r.a -= cpu._r.c; cpu._r.a -= ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.c ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void SBCr_d() { var a = cpu._r.a; cpu._r.a -= cpu._r.d; cpu._r.a -= ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.d ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void SBCr_e() { var a = cpu._r.a; cpu._r.a -= cpu._r.e; cpu._r.a -= ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.e ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void SBCr_h() { var a = cpu._r.a; cpu._r.a -= cpu._r.h; cpu._r.a -= ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.h ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void SBCr_l() { var a = cpu._r.a; cpu._r.a -= cpu._r.l; cpu._r.a -= ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.l ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void SBCr_a() { var a = cpu._r.a; cpu._r.a -= cpu._r.a; cpu._r.a -= ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.a ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void SBCHL() { var a = cpu._r.a; var m = MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.a -= m; cpu._r.a -= ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ m ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 2; }
            public static void SBCn() { var a = cpu._r.a; var m = MMU.rb(cpu._r.pc); cpu._r.a -= m; cpu._r.pc++; cpu._r.a -= ((cpu._r.f & 0x10) != 0) ? 1 : 0; cpu._r.f = (cpu._r.a < 0) ? 0x50 : 0x40; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ m ^ a) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 2; }

            public static void CPr_b() { var i = cpu._r.a; i -= cpu._r.b; cpu._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.b ^ i) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void CPr_c() { var i = cpu._r.a; i -= cpu._r.c; cpu._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.c ^ i) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void CPr_d() { var i = cpu._r.a; i -= cpu._r.d; cpu._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.d ^ i) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void CPr_e() { var i = cpu._r.a; i -= cpu._r.e; cpu._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.e ^ i) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void CPr_h() { var i = cpu._r.a; i -= cpu._r.h; cpu._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.h ^ i) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void CPr_l() { var i = cpu._r.a; i -= cpu._r.l; cpu._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.l ^ i) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void CPr_a() { var i = cpu._r.a; i -= cpu._r.a; cpu._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ cpu._r.a ^ i) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 1; }
            public static void CPHL() { var i = cpu._r.a; var m = MMU.rb((cpu._r.h << 8) + cpu._r.l); i -= m; cpu._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ i ^ m) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 2; }
            public static void CPn() { var i = cpu._r.a; var m = MMU.rb(cpu._r.pc); i -= m; cpu._r.pc++; cpu._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) cpu._r.f |= 0x80; if (((cpu._r.a ^ i ^ m) & 0x10) != 0) cpu._r.f |= 0x20; cpu._r.m = 2; }

            public static void DAA() { var a = cpu._r.a; if (((cpu._r.f & 0x20) != 0) || ((cpu._r.a & 15) > 9)) cpu._r.a += 6; cpu._r.f &= 0xEF; if (((cpu._r.f & 0x20) != 0) || (a > 0x99)) { cpu._r.a += 0x60; cpu._r.f |= 0x10; } cpu._r.m = 1; }

            public static void ANDr_b() { cpu._r.a &= cpu._r.b; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void ANDr_c() { cpu._r.a &= cpu._r.c; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void ANDr_d() { cpu._r.a &= cpu._r.d; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void ANDr_e() { cpu._r.a &= cpu._r.e; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void ANDr_h() { cpu._r.a &= cpu._r.h; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void ANDr_l() { cpu._r.a &= cpu._r.l; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void ANDr_a() { cpu._r.a &= cpu._r.a; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void ANDHL() { cpu._r.a &= MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void ANDn() { cpu._r.a &= MMU.rb(cpu._r.pc); cpu._r.pc++; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 2; }

            public static void ORr_b() { cpu._r.a |= cpu._r.b; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void ORr_c() { cpu._r.a |= cpu._r.c; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void ORr_d() { cpu._r.a |= cpu._r.d; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void ORr_e() { cpu._r.a |= cpu._r.e; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void ORr_h() { cpu._r.a |= cpu._r.h; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void ORr_l() { cpu._r.a |= cpu._r.l; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void ORr_a() { cpu._r.a |= cpu._r.a; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void ORHL() { cpu._r.a |= MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void ORn() { cpu._r.a |= MMU.rb(cpu._r.pc); cpu._r.pc++; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 2; }

            public static void XORr_b() { cpu._r.a ^= cpu._r.b; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void XORr_c() { cpu._r.a ^= cpu._r.c; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void XORr_d() { cpu._r.a ^= cpu._r.d; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void XORr_e() { cpu._r.a ^= cpu._r.e; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void XORr_h() { cpu._r.a ^= cpu._r.h; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void XORr_l() { cpu._r.a ^= cpu._r.l; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void XORr_a() { cpu._r.a ^= cpu._r.a; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void XORHL() { cpu._r.a ^= MMU.rb((cpu._r.h << 8) + cpu._r.l); cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void XORn() { cpu._r.a ^= MMU.rb(cpu._r.pc); cpu._r.pc++; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 2; }

            public static void INCr_b() { cpu._r.b++; cpu._r.b &= 255; cpu._r.f = cpu._r.b != 0? 0 : 0x80; cpu._r.m = 1; }
            public static void INCr_c() { cpu._r.c++; cpu._r.c &= 255; cpu._r.f = cpu._r.c != 0? 0 : 0x80; cpu._r.m = 1; }
            public static void INCr_d() { cpu._r.d++; cpu._r.d &= 255; cpu._r.f = cpu._r.d != 0? 0 : 0x80; cpu._r.m = 1; }
            public static void INCr_e() { cpu._r.e++; cpu._r.e &= 255; cpu._r.f = cpu._r.e != 0? 0 : 0x80; cpu._r.m = 1; }
            public static void INCr_h() { cpu._r.h++; cpu._r.h &= 255; cpu._r.f = cpu._r.h != 0? 0 : 0x80; cpu._r.m = 1; }
            public static void INCr_l() { cpu._r.l++; cpu._r.l &= 255; cpu._r.f = cpu._r.l != 0? 0 : 0x80; cpu._r.m = 1; }
            public static void INCr_a() { cpu._r.a++; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0? 0 : 0x80; cpu._r.m = 1; }
            public static void INCHLm() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l) + 1; i &= 255; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.f = i != 0 ? 0 : 0x80; cpu._r.m = 3; }

            public static void DECr_b() { cpu._r.b--; cpu._r.b &= 255; cpu._r.f = cpu._r.b != 0? 0 : 0x80; cpu._r.m = 1; }
            public static void DECr_c() { cpu._r.c--; cpu._r.c &= 255; cpu._r.f = cpu._r.c != 0? 0 : 0x80; cpu._r.m = 1; }
            public static void DECr_d() { cpu._r.d--; cpu._r.d &= 255; cpu._r.f = cpu._r.d != 0? 0 : 0x80; cpu._r.m = 1; }
            public static void DECr_e() { cpu._r.e--; cpu._r.e &= 255; cpu._r.f = cpu._r.e != 0? 0 : 0x80; cpu._r.m = 1; }
            public static void DECr_h() { cpu._r.h--; cpu._r.h &= 255; cpu._r.f = cpu._r.h != 0? 0 : 0x80; cpu._r.m = 1; }
            public static void DECr_l() { cpu._r.l--; cpu._r.l &= 255; cpu._r.f = cpu._r.l != 0? 0 : 0x80; cpu._r.m = 1; }
            public static void DECr_a() { cpu._r.a--; cpu._r.a &= 255; cpu._r.f = cpu._r.a != 0? 0 : 0x80; cpu._r.m = 1; }
            public static void DECHLm() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l) - 1; i &= 255; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.f = i != 0 ? 0 : 0x80; cpu._r.m = 3; }

            public static void INCBC() { cpu._r.c = (cpu._r.c + 1) & 255; if (cpu._r.c == 0) cpu._r.b = (cpu._r.b + 1) & 255; cpu._r.m = 1; }
            public static void INCDE() { cpu._r.e = (cpu._r.e + 1) & 255; if (cpu._r.e == 0) cpu._r.d = (cpu._r.d + 1) & 255; cpu._r.m = 1; }
            public static void INCHL() { cpu._r.l = (cpu._r.l + 1) & 255; if (cpu._r.l == 0) cpu._r.h = (cpu._r.h + 1) & 255; cpu._r.m = 1; }
            public static void INCSP() { cpu._r.sp = (cpu._r.sp + 1) & 65535; cpu._r.m = 1; }

            public static void DECBC() { cpu._r.c = (cpu._r.c - 1) & 255; if (cpu._r.c == 255) cpu._r.b = (cpu._r.b - 1) & 255; cpu._r.m = 1; }
            public static void DECDE() { cpu._r.e = (cpu._r.e - 1) & 255; if (cpu._r.e == 255) cpu._r.d = (cpu._r.d - 1) & 255; cpu._r.m = 1; }
            public static void DECHL() { cpu._r.l = (cpu._r.l - 1) & 255; if (cpu._r.l == 255) cpu._r.h = (cpu._r.h - 1) & 255; cpu._r.m = 1; }
            public static void DECSP() { cpu._r.sp = (cpu._r.sp - 1) & 65535; cpu._r.m = 1; }

            /*--- Bit manipulation ---*/
            public static void BIT0b() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.b & 0x01) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT0c() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.c & 0x01) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT0d() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.d & 0x01) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT0e() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.e & 0x01) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT0h() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.h & 0x01) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT0l() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.l & 0x01) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT0a() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.a & 0x01) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT0m() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (MMU.rb((cpu._r.h << 8) + cpu._r.l) & 0x01) != 0 ? 0 : 0x80; cpu._r.m = 3; }

            public static void RES0b() { cpu._r.b &= 0xFE; cpu._r.m = 2; }
            public static void RES0c() { cpu._r.c &= 0xFE; cpu._r.m = 2; }
            public static void RES0d() { cpu._r.d &= 0xFE; cpu._r.m = 2; }
            public static void RES0e() { cpu._r.e &= 0xFE; cpu._r.m = 2; }
            public static void RES0h() { cpu._r.h &= 0xFE; cpu._r.m = 2; }
            public static void RES0l() { cpu._r.l &= 0xFE; cpu._r.m = 2; }
            public static void RES0a() { cpu._r.a &= 0xFE; cpu._r.m = 2; }
            public static void RES0m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i &= 0xFE; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void SET0b() { cpu._r.b |= 0x01; cpu._r.m = 2; }
            public static void SET0c() { cpu._r.b |= 0x01; cpu._r.m = 2; }
            public static void SET0d() { cpu._r.b |= 0x01; cpu._r.m = 2; }
            public static void SET0e() { cpu._r.b |= 0x01; cpu._r.m = 2; }
            public static void SET0h() { cpu._r.b |= 0x01; cpu._r.m = 2; }
            public static void SET0l() { cpu._r.b |= 0x01; cpu._r.m = 2; }
            public static void SET0a() { cpu._r.b |= 0x01; cpu._r.m = 2; }
            public static void SET0m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i |= 0x01; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void BIT1b() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.b & 0x02) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT1c() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.c & 0x02) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT1d() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.d & 0x02) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT1e() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.e & 0x02) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT1h() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.h & 0x02) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT1l() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.l & 0x02) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT1a() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.a & 0x02) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT1m() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (MMU.rb((cpu._r.h << 8) + cpu._r.l) & 0x02) != 0 ? 0 : 0x80; cpu._r.m = 3; }

            public static void RES1b() { cpu._r.b &= 0xFD; cpu._r.m = 2; }
            public static void RES1c() { cpu._r.c &= 0xFD; cpu._r.m = 2; }
            public static void RES1d() { cpu._r.d &= 0xFD; cpu._r.m = 2; }
            public static void RES1e() { cpu._r.e &= 0xFD; cpu._r.m = 2; }
            public static void RES1h() { cpu._r.h &= 0xFD; cpu._r.m = 2; }
            public static void RES1l() { cpu._r.l &= 0xFD; cpu._r.m = 2; }
            public static void RES1a() { cpu._r.a &= 0xFD; cpu._r.m = 2; }
            public static void RES1m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i &= 0xFD; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void SET1b() { cpu._r.b |= 0x02; cpu._r.m = 2; }
            public static void SET1c() { cpu._r.b |= 0x02; cpu._r.m = 2; }
            public static void SET1d() { cpu._r.b |= 0x02; cpu._r.m = 2; }
            public static void SET1e() { cpu._r.b |= 0x02; cpu._r.m = 2; }
            public static void SET1h() { cpu._r.b |= 0x02; cpu._r.m = 2; }
            public static void SET1l() { cpu._r.b |= 0x02; cpu._r.m = 2; }
            public static void SET1a() { cpu._r.b |= 0x02; cpu._r.m = 2; }
            public static void SET1m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i |= 0x02; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void BIT2b() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.b & 0x04) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT2c() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.c & 0x04) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT2d() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.d & 0x04) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT2e() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.e & 0x04) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT2h() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.h & 0x04) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT2l() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.l & 0x04) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT2a() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.a & 0x04) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT2m() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (MMU.rb((cpu._r.h << 8) + cpu._r.l) & 0x04) != 0 ? 0 : 0x80; cpu._r.m = 3; }

            public static void RES2b() { cpu._r.b &= 0xFB; cpu._r.m = 2; }
            public static void RES2c() { cpu._r.c &= 0xFB; cpu._r.m = 2; }
            public static void RES2d() { cpu._r.d &= 0xFB; cpu._r.m = 2; }
            public static void RES2e() { cpu._r.e &= 0xFB; cpu._r.m = 2; }
            public static void RES2h() { cpu._r.h &= 0xFB; cpu._r.m = 2; }
            public static void RES2l() { cpu._r.l &= 0xFB; cpu._r.m = 2; }
            public static void RES2a() { cpu._r.a &= 0xFB; cpu._r.m = 2; }
            public static void RES2m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i &= 0xFB; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void SET2b() { cpu._r.b |= 0x04; cpu._r.m = 2; }
            public static void SET2c() { cpu._r.b |= 0x04; cpu._r.m = 2; }
            public static void SET2d() { cpu._r.b |= 0x04; cpu._r.m = 2; }
            public static void SET2e() { cpu._r.b |= 0x04; cpu._r.m = 2; }
            public static void SET2h() { cpu._r.b |= 0x04; cpu._r.m = 2; }
            public static void SET2l() { cpu._r.b |= 0x04; cpu._r.m = 2; }
            public static void SET2a() { cpu._r.b |= 0x04; cpu._r.m = 2; }
            public static void SET2m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i |= 0x04; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void BIT3b() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.b & 0x08) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT3c() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.c & 0x08) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT3d() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.d & 0x08) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT3e() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.e & 0x08) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT3h() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.h & 0x08) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT3l() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.l & 0x08) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT3a() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.a & 0x08) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT3m() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (MMU.rb((cpu._r.h << 8) + cpu._r.l) & 0x08) != 0 ? 0 : 0x80; cpu._r.m = 3; }

            public static void RES3b() { cpu._r.b &= 0xF7; cpu._r.m = 2; }
            public static void RES3c() { cpu._r.c &= 0xF7; cpu._r.m = 2; }
            public static void RES3d() { cpu._r.d &= 0xF7; cpu._r.m = 2; }
            public static void RES3e() { cpu._r.e &= 0xF7; cpu._r.m = 2; }
            public static void RES3h() { cpu._r.h &= 0xF7; cpu._r.m = 2; }
            public static void RES3l() { cpu._r.l &= 0xF7; cpu._r.m = 2; }
            public static void RES3a() { cpu._r.a &= 0xF7; cpu._r.m = 2; }
            public static void RES3m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i &= 0xF7; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void SET3b() { cpu._r.b |= 0x08; cpu._r.m = 2; }
            public static void SET3c() { cpu._r.b |= 0x08; cpu._r.m = 2; }
            public static void SET3d() { cpu._r.b |= 0x08; cpu._r.m = 2; }
            public static void SET3e() { cpu._r.b |= 0x08; cpu._r.m = 2; }
            public static void SET3h() { cpu._r.b |= 0x08; cpu._r.m = 2; }
            public static void SET3l() { cpu._r.b |= 0x08; cpu._r.m = 2; }
            public static void SET3a() { cpu._r.b |= 0x08; cpu._r.m = 2; }
            public static void SET3m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i |= 0x08; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void BIT4b() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.b & 0x10) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT4c() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.c & 0x10) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT4d() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.d & 0x10) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT4e() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.e & 0x10) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT4h() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.h & 0x10) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT4l() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.l & 0x10) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT4a() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.a & 0x10) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT4m() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (MMU.rb((cpu._r.h << 8) + cpu._r.l) & 0x10) != 0 ? 0 : 0x80; cpu._r.m = 3; }

            public static void RES4b() { cpu._r.b &= 0xEF; cpu._r.m = 2; }
            public static void RES4c() { cpu._r.c &= 0xEF; cpu._r.m = 2; }
            public static void RES4d() { cpu._r.d &= 0xEF; cpu._r.m = 2; }
            public static void RES4e() { cpu._r.e &= 0xEF; cpu._r.m = 2; }
            public static void RES4h() { cpu._r.h &= 0xEF; cpu._r.m = 2; }
            public static void RES4l() { cpu._r.l &= 0xEF; cpu._r.m = 2; }
            public static void RES4a() { cpu._r.a &= 0xEF; cpu._r.m = 2; }
            public static void RES4m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i &= 0xEF; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void SET4b() { cpu._r.b |= 0x10; cpu._r.m = 2; }
            public static void SET4c() { cpu._r.b |= 0x10; cpu._r.m = 2; }
            public static void SET4d() { cpu._r.b |= 0x10; cpu._r.m = 2; }
            public static void SET4e() { cpu._r.b |= 0x10; cpu._r.m = 2; }
            public static void SET4h() { cpu._r.b |= 0x10; cpu._r.m = 2; }
            public static void SET4l() { cpu._r.b |= 0x10; cpu._r.m = 2; }
            public static void SET4a() { cpu._r.b |= 0x10; cpu._r.m = 2; }
            public static void SET4m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i |= 0x10; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void BIT5b() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.b & 0x20) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT5c() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.c & 0x20) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT5d() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.d & 0x20) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT5e() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.e & 0x20) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT5h() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.h & 0x20) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT5l() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.l & 0x20) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT5a() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.a & 0x20) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT5m() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (MMU.rb((cpu._r.h << 8) + cpu._r.l) & 0x20) != 0 ? 0 : 0x80; cpu._r.m = 3; }

            public static void RES5b() { cpu._r.b &= 0xDF; cpu._r.m = 2; }
            public static void RES5c() { cpu._r.c &= 0xDF; cpu._r.m = 2; }
            public static void RES5d() { cpu._r.d &= 0xDF; cpu._r.m = 2; }
            public static void RES5e() { cpu._r.e &= 0xDF; cpu._r.m = 2; }
            public static void RES5h() { cpu._r.h &= 0xDF; cpu._r.m = 2; }
            public static void RES5l() { cpu._r.l &= 0xDF; cpu._r.m = 2; }
            public static void RES5a() { cpu._r.a &= 0xDF; cpu._r.m = 2; }
            public static void RES5m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i &= 0xDF; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void SET5b() { cpu._r.b |= 0x20; cpu._r.m = 2; }
            public static void SET5c() { cpu._r.b |= 0x20; cpu._r.m = 2; }
            public static void SET5d() { cpu._r.b |= 0x20; cpu._r.m = 2; }
            public static void SET5e() { cpu._r.b |= 0x20; cpu._r.m = 2; }
            public static void SET5h() { cpu._r.b |= 0x20; cpu._r.m = 2; }
            public static void SET5l() { cpu._r.b |= 0x20; cpu._r.m = 2; }
            public static void SET5a() { cpu._r.b |= 0x20; cpu._r.m = 2; }
            public static void SET5m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i |= 0x20; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void BIT6b() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.b & 0x40) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT6c() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.c & 0x40) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT6d() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.d & 0x40) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT6e() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.e & 0x40) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT6h() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.h & 0x40) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT6l() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.l & 0x40) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT6a() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.a & 0x40) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT6m() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (MMU.rb((cpu._r.h << 8) + cpu._r.l) & 0x40) != 0 ? 0 : 0x80; cpu._r.m = 3; }

            public static void RES6b() { cpu._r.b &= 0xBF; cpu._r.m = 2; }
            public static void RES6c() { cpu._r.c &= 0xBF; cpu._r.m = 2; }
            public static void RES6d() { cpu._r.d &= 0xBF; cpu._r.m = 2; }
            public static void RES6e() { cpu._r.e &= 0xBF; cpu._r.m = 2; }
            public static void RES6h() { cpu._r.h &= 0xBF; cpu._r.m = 2; }
            public static void RES6l() { cpu._r.l &= 0xBF; cpu._r.m = 2; }
            public static void RES6a() { cpu._r.a &= 0xBF; cpu._r.m = 2; }
            public static void RES6m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i &= 0xBF; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void SET6b() { cpu._r.b |= 0x40; cpu._r.m = 2; }
            public static void SET6c() { cpu._r.b |= 0x40; cpu._r.m = 2; }
            public static void SET6d() { cpu._r.b |= 0x40; cpu._r.m = 2; }
            public static void SET6e() { cpu._r.b |= 0x40; cpu._r.m = 2; }
            public static void SET6h() { cpu._r.b |= 0x40; cpu._r.m = 2; }
            public static void SET6l() { cpu._r.b |= 0x40; cpu._r.m = 2; }
            public static void SET6a() { cpu._r.b |= 0x40; cpu._r.m = 2; }
            public static void SET6m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i |= 0x40; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void BIT7b() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.b & 0x80) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT7c() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.c & 0x80) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT7d() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.d & 0x80) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT7e() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.e & 0x80) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT7h() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.h & 0x80) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT7l() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.l & 0x80) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT7a() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (cpu._r.a & 0x80) != 0 ? 0 : 0x80; cpu._r.m = 2; }
            public static void BIT7m() { cpu._r.f &= 0x1F; cpu._r.f |= 0x20; cpu._r.f = (MMU.rb((cpu._r.h << 8) + cpu._r.l) & 0x80) != 0 ? 0 : 0x80; cpu._r.m = 3; }

            public static void RES7b() { cpu._r.b &= 0x7F; cpu._r.m = 2; }
            public static void RES7c() { cpu._r.c &= 0x7F; cpu._r.m = 2; }
            public static void RES7d() { cpu._r.d &= 0x7F; cpu._r.m = 2; }
            public static void RES7e() { cpu._r.e &= 0x7F; cpu._r.m = 2; }
            public static void RES7h() { cpu._r.h &= 0x7F; cpu._r.m = 2; }
            public static void RES7l() { cpu._r.l &= 0x7F; cpu._r.m = 2; }
            public static void RES7a() { cpu._r.a &= 0x7F; cpu._r.m = 2; }
            public static void RES7m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i &= 0x7F; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void SET7b() { cpu._r.b |= 0x80; cpu._r.m = 2; }
            public static void SET7c() { cpu._r.b |= 0x80; cpu._r.m = 2; }
            public static void SET7d() { cpu._r.b |= 0x80; cpu._r.m = 2; }
            public static void SET7e() { cpu._r.b |= 0x80; cpu._r.m = 2; }
            public static void SET7h() { cpu._r.b |= 0x80; cpu._r.m = 2; }
            public static void SET7l() { cpu._r.b |= 0x80; cpu._r.m = 2; }
            public static void SET7a() { cpu._r.b |= 0x80; cpu._r.m = 2; }
            public static void SET7m() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); i |= 0x80; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.m = 4; }

            public static void RLA() { var ci = (cpu._r.f & 0x10) != 0 ? 1 : 0; var co = (cpu._r.a & 0x80) != 0 ? 0x10 : 0; cpu._r.a = (cpu._r.a << 1) + ci; cpu._r.a &= 255; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 1; }
            public static void RLCA() { var ci = (cpu._r.a & 0x80) != 0 ? 1 : 0; var co = (cpu._r.a & 0x80) != 0 ? 0x10 : 0; cpu._r.a = (cpu._r.a << 1) + ci; cpu._r.a &= 255; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 1; }
            public static void RRA() { var ci = (cpu._r.f & 0x10) != 0 ? 0x80 : 0; var co = (cpu._r.a & 1) != 0 ? 0x10 : 0; cpu._r.a = (cpu._r.a >> 1) + ci; cpu._r.a &= 255; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 1; }
            public static void RRCA() { var ci = (cpu._r.a & 1) != 0 ? 0x80 : 0; var co = (cpu._r.a & 1) != 0 ? 0x10 : 0; cpu._r.a = (cpu._r.a >> 1) + ci; cpu._r.a &= 255; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 1; }

            public static void RLr_b() { var ci = (cpu._r.f & 0x10) != 0 ? 1 : 0; var co = (cpu._r.b & 0x80) != 0 ? 0x10 : 0; cpu._r.b = (cpu._r.b << 1) + ci; cpu._r.b &= 255; cpu._r.f = (cpu._r.b != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RLr_c() { var ci = (cpu._r.f & 0x10) != 0 ? 1 : 0; var co = (cpu._r.c & 0x80) != 0 ? 0x10 : 0; cpu._r.c = (cpu._r.c << 1) + ci; cpu._r.c &= 255; cpu._r.f = (cpu._r.c != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RLr_d() { var ci = (cpu._r.f & 0x10) != 0 ? 1 : 0; var co = (cpu._r.d & 0x80) != 0 ? 0x10 : 0; cpu._r.d = (cpu._r.d << 1) + ci; cpu._r.d &= 255; cpu._r.f = (cpu._r.d != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RLr_e() { var ci = (cpu._r.f & 0x10) != 0 ? 1 : 0; var co = (cpu._r.e & 0x80) != 0 ? 0x10 : 0; cpu._r.e = (cpu._r.e << 1) + ci; cpu._r.e &= 255; cpu._r.f = (cpu._r.e != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RLr_h() { var ci = (cpu._r.f & 0x10) != 0 ? 1 : 0; var co = (cpu._r.h & 0x80) != 0 ? 0x10 : 0; cpu._r.h = (cpu._r.h << 1) + ci; cpu._r.h &= 255; cpu._r.f = (cpu._r.h != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RLr_l() { var ci = (cpu._r.f & 0x10) != 0 ? 1 : 0; var co = (cpu._r.l & 0x80) != 0 ? 0x10 : 0; cpu._r.l = (cpu._r.l << 1) + ci; cpu._r.l &= 255; cpu._r.f = (cpu._r.l != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RLr_a() { var ci = (cpu._r.f & 0x10) != 0 ? 1 : 0; var co = (cpu._r.a & 0x80) != 0 ? 0x10 : 0; cpu._r.a = (cpu._r.a << 1) + ci; cpu._r.a &= 255; cpu._r.f = (cpu._r.a != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RLHL() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); var ci = (cpu._r.f & 0x10) != 0 ? 1 : 0; var co = ((i & 0x80) != 0) ? 0x10 : 0; i = (i << 1) + ci; i &= 255; cpu._r.f = (i != 0) ? 0 : 0x80; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 4; }

            public static void RLCr_b() { var ci = (cpu._r.b & 0x80) != 0 ? 1 : 0; var co = (cpu._r.b & 0x80) != 0 ? 0x10 : 0; cpu._r.b = (cpu._r.b << 1) + ci; cpu._r.b &= 255; cpu._r.f = (cpu._r.b != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RLCr_c() { var ci = (cpu._r.c & 0x80) != 0 ? 1 : 0; var co = (cpu._r.c & 0x80) != 0 ? 0x10 : 0; cpu._r.c = (cpu._r.c << 1) + ci; cpu._r.c &= 255; cpu._r.f = (cpu._r.c != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RLCr_d() { var ci = (cpu._r.d & 0x80) != 0 ? 1 : 0; var co = (cpu._r.d & 0x80) != 0 ? 0x10 : 0; cpu._r.d = (cpu._r.d << 1) + ci; cpu._r.d &= 255; cpu._r.f = (cpu._r.d != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RLCr_e() { var ci = (cpu._r.e & 0x80) != 0 ? 1 : 0; var co = (cpu._r.e & 0x80) != 0 ? 0x10 : 0; cpu._r.e = (cpu._r.e << 1) + ci; cpu._r.e &= 255; cpu._r.f = (cpu._r.e != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RLCr_h() { var ci = (cpu._r.h & 0x80) != 0 ? 1 : 0; var co = (cpu._r.h & 0x80) != 0 ? 0x10 : 0; cpu._r.h = (cpu._r.h << 1) + ci; cpu._r.h &= 255; cpu._r.f = (cpu._r.h != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RLCr_l() { var ci = (cpu._r.l & 0x80) != 0 ? 1 : 0; var co = (cpu._r.l & 0x80) != 0 ? 0x10 : 0; cpu._r.l = (cpu._r.l << 1) + ci; cpu._r.l &= 255; cpu._r.f = (cpu._r.l != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RLCr_a() { var ci = (cpu._r.a & 0x80) != 0 ? 1 : 0; var co = (cpu._r.a & 0x80) != 0 ? 0x10 : 0; cpu._r.a = (cpu._r.a << 1) + ci; cpu._r.a &= 255; cpu._r.f = (cpu._r.a != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RLCHL() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); var ci = (i & 0x80) != 0 ? 1 : 0; var co = (i & 0x80) != 0 ? 0x10 : 0; i = (i << 1) + ci; i &= 255; cpu._r.f = (i != 0) ? 0 : 0x80; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 4; }

            public static void RRr_b() { var ci = (cpu._r.f & 0x10) != 0 ? 0x80 : 0; var co = (cpu._r.b & 1) != 0 ? 0x10 : 0; cpu._r.b = (cpu._r.b >> 1) + ci; cpu._r.b &= 255; cpu._r.f = (cpu._r.b != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RRr_c() { var ci = (cpu._r.f & 0x10) != 0 ? 0x80 : 0; var co = (cpu._r.c & 1) != 0 ? 0x10 : 0; cpu._r.c = (cpu._r.c >> 1) + ci; cpu._r.c &= 255; cpu._r.f = (cpu._r.c != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RRr_d() { var ci = (cpu._r.f & 0x10) != 0 ? 0x80 : 0; var co = (cpu._r.d & 1) != 0 ? 0x10 : 0; cpu._r.d = (cpu._r.d >> 1) + ci; cpu._r.d &= 255; cpu._r.f = (cpu._r.d != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RRr_e() { var ci = (cpu._r.f & 0x10) != 0 ? 0x80 : 0; var co = (cpu._r.e & 1) != 0 ? 0x10 : 0; cpu._r.e = (cpu._r.e >> 1) + ci; cpu._r.e &= 255; cpu._r.f = (cpu._r.e != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RRr_h() { var ci = (cpu._r.f & 0x10) != 0 ? 0x80 : 0; var co = (cpu._r.h & 1) != 0 ? 0x10 : 0; cpu._r.h = (cpu._r.h >> 1) + ci; cpu._r.h &= 255; cpu._r.f = (cpu._r.h != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RRr_l() { var ci = (cpu._r.f & 0x10) != 0 ? 0x80 : 0; var co = (cpu._r.l & 1) != 0 ? 0x10 : 0; cpu._r.l = (cpu._r.l >> 1) + ci; cpu._r.l &= 255; cpu._r.f = (cpu._r.l != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RRr_a() { var ci = (cpu._r.f & 0x10) != 0 ? 0x80 : 0; var co = (cpu._r.a & 1) != 0 ? 0x10 : 0; cpu._r.a = (cpu._r.a >> 1) + ci; cpu._r.a &= 255; cpu._r.f = (cpu._r.a != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RRHL() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); var ci = (cpu._r.f & 0x10) != 0 ? 0x80 : 0; var co = (i & 1) != 0 ? 0x10 : 0; i = (i >> 1) + ci; i &= 255; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.f = (i != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 4; }

            public static void RRCr_b() { var ci = (cpu._r.b & 1) != 0 ? 0x80 : 0; var co = (cpu._r.b & 1) != 0 ? 0x10 : 0; cpu._r.b = (cpu._r.b >> 1) + ci; cpu._r.b &= 255; cpu._r.f = (cpu._r.b != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RRCr_c() { var ci = (cpu._r.c & 1) != 0 ? 0x80 : 0; var co = (cpu._r.c & 1) != 0 ? 0x10 : 0; cpu._r.c = (cpu._r.c >> 1) + ci; cpu._r.c &= 255; cpu._r.f = (cpu._r.c != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RRCr_d() { var ci = (cpu._r.d & 1) != 0 ? 0x80 : 0; var co = (cpu._r.d & 1) != 0 ? 0x10 : 0; cpu._r.d = (cpu._r.d >> 1) + ci; cpu._r.d &= 255; cpu._r.f = (cpu._r.d != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RRCr_e() { var ci = (cpu._r.e & 1) != 0 ? 0x80 : 0; var co = (cpu._r.e & 1) != 0 ? 0x10 : 0; cpu._r.e = (cpu._r.e >> 1) + ci; cpu._r.e &= 255; cpu._r.f = (cpu._r.e != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RRCr_h() { var ci = (cpu._r.h & 1) != 0 ? 0x80 : 0; var co = (cpu._r.h & 1) != 0 ? 0x10 : 0; cpu._r.h = (cpu._r.h >> 1) + ci; cpu._r.h &= 255; cpu._r.f = (cpu._r.h != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RRCr_l() { var ci = (cpu._r.l & 1) != 0 ? 0x80 : 0; var co = (cpu._r.l & 1) != 0 ? 0x10 : 0; cpu._r.l = (cpu._r.l >> 1) + ci; cpu._r.l &= 255; cpu._r.f = (cpu._r.l != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RRCr_a() { var ci = (cpu._r.a & 1) != 0 ? 0x80 : 0; var co = (cpu._r.a & 1) != 0 ? 0x10 : 0; cpu._r.a = (cpu._r.a >> 1) + ci; cpu._r.a &= 255; cpu._r.f = (cpu._r.a != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void RRCHL() { var i = MMU.rb((cpu._r.h << 8) + cpu._r.l); var ci = (i & 1) != 0 ? 0x80 : 0; var co = (i & 1) != 0 ? 0x10 : 0; i = (i >> 1) + ci; i &= 255; MMU.wb((cpu._r.h << 8) + cpu._r.l, i); cpu._r.f = (i != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 4; }

            public static void SLAr_b() { var co = (cpu._r.b & 0x80) != 0 ? 0x10 : 0; cpu._r.b = (cpu._r.b << 1) & 255; cpu._r.f = (cpu._r.b != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SLAr_c() { var co = (cpu._r.c & 0x80) != 0 ? 0x10 : 0; cpu._r.c = (cpu._r.c << 1) & 255; cpu._r.f = (cpu._r.c != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SLAr_d() { var co = (cpu._r.d & 0x80) != 0 ? 0x10 : 0; cpu._r.d = (cpu._r.d << 1) & 255; cpu._r.f = (cpu._r.d != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SLAr_e() { var co = (cpu._r.e & 0x80) != 0 ? 0x10 : 0; cpu._r.e = (cpu._r.e << 1) & 255; cpu._r.f = (cpu._r.e != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SLAr_h() { var co = (cpu._r.h & 0x80) != 0 ? 0x10 : 0; cpu._r.h = (cpu._r.h << 1) & 255; cpu._r.f = (cpu._r.h != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SLAr_l() { var co = (cpu._r.l & 0x80) != 0 ? 0x10 : 0; cpu._r.l = (cpu._r.l << 1) & 255; cpu._r.f = (cpu._r.l != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SLAr_a() { var co = (cpu._r.a & 0x80) != 0 ? 0x10 : 0; cpu._r.a = (cpu._r.a << 1) & 255; cpu._r.f = (cpu._r.a != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }

            public static void SLLr_b() { var co = (cpu._r.b & 0x80) != 0 ? 0x10 : 0; cpu._r.b = (cpu._r.b << 1) & 255 + 1; cpu._r.f = (cpu._r.b != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SLLr_c() { var co = (cpu._r.c & 0x80) != 0 ? 0x10 : 0; cpu._r.c = (cpu._r.c << 1) & 255 + 1; cpu._r.f = (cpu._r.c != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SLLr_d() { var co = (cpu._r.d & 0x80) != 0 ? 0x10 : 0; cpu._r.d = (cpu._r.d << 1) & 255 + 1; cpu._r.f = (cpu._r.d != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SLLr_e() { var co = (cpu._r.e & 0x80) != 0 ? 0x10 : 0; cpu._r.e = (cpu._r.e << 1) & 255 + 1; cpu._r.f = (cpu._r.e != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SLLr_h() { var co = (cpu._r.h & 0x80) != 0 ? 0x10 : 0; cpu._r.h = (cpu._r.h << 1) & 255 + 1; cpu._r.f = (cpu._r.h != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SLLr_l() { var co = (cpu._r.l & 0x80) != 0 ? 0x10 : 0; cpu._r.l = (cpu._r.l << 1) & 255 + 1; cpu._r.f = (cpu._r.l != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SLLr_a() { var co = (cpu._r.a & 0x80) != 0 ? 0x10 : 0; cpu._r.a = (cpu._r.a << 1) & 255 + 1; cpu._r.f = (cpu._r.a != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }

            public static void SRAr_b() { var ci = cpu._r.b & 0x80; var co = (cpu._r.b & 1) != 0 ? 0x10 : 0; cpu._r.b = ((cpu._r.b >> 1) + ci) & 255; cpu._r.f = (cpu._r.b != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SRAr_c() { var ci = cpu._r.c & 0x80; var co = (cpu._r.c & 1) != 0 ? 0x10 : 0; cpu._r.c = ((cpu._r.c >> 1) + ci) & 255; cpu._r.f = (cpu._r.c != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SRAr_d() { var ci = cpu._r.d & 0x80; var co = (cpu._r.d & 1) != 0 ? 0x10 : 0; cpu._r.d = ((cpu._r.d >> 1) + ci) & 255; cpu._r.f = (cpu._r.d != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SRAr_e() { var ci = cpu._r.e & 0x80; var co = (cpu._r.e & 1) != 0 ? 0x10 : 0; cpu._r.e = ((cpu._r.e >> 1) + ci) & 255; cpu._r.f = (cpu._r.e != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SRAr_h() { var ci = cpu._r.h & 0x80; var co = (cpu._r.h & 1) != 0 ? 0x10 : 0; cpu._r.h = ((cpu._r.h >> 1) + ci) & 255; cpu._r.f = (cpu._r.h != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SRAr_l() { var ci = cpu._r.l & 0x80; var co = (cpu._r.l & 1) != 0 ? 0x10 : 0; cpu._r.l = ((cpu._r.l >> 1) + ci) & 255; cpu._r.f = (cpu._r.l != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SRAr_a() { var ci = cpu._r.a & 0x80; var co = (cpu._r.a & 1) != 0 ? 0x10 : 0; cpu._r.a = ((cpu._r.a >> 1) + ci) & 255; cpu._r.f = (cpu._r.a != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }

            public static void SRLr_b() { var co = (cpu._r.b & 1) != 0 ? 0x10 : 0; cpu._r.b = (cpu._r.b >> 1) & 255; cpu._r.f = (cpu._r.b != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SRLr_c() { var co = (cpu._r.c & 1) != 0 ? 0x10 : 0; cpu._r.c = (cpu._r.c >> 1) & 255; cpu._r.f = (cpu._r.c != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SRLr_d() { var co = (cpu._r.d & 1) != 0 ? 0x10 : 0; cpu._r.d = (cpu._r.d >> 1) & 255; cpu._r.f = (cpu._r.d != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SRLr_e() { var co = (cpu._r.e & 1) != 0 ? 0x10 : 0; cpu._r.e = (cpu._r.e >> 1) & 255; cpu._r.f = (cpu._r.e != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SRLr_h() { var co = (cpu._r.h & 1) != 0 ? 0x10 : 0; cpu._r.h = (cpu._r.h >> 1) & 255; cpu._r.f = (cpu._r.h != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SRLr_l() { var co = (cpu._r.l & 1) != 0 ? 0x10 : 0; cpu._r.l = (cpu._r.l >> 1) & 255; cpu._r.f = (cpu._r.l != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }
            public static void SRLr_a() { var co = (cpu._r.a & 1) != 0 ? 0x10 : 0; cpu._r.a = (cpu._r.a >> 1) & 255; cpu._r.f = (cpu._r.a != 0) ? 0 : 0x80; cpu._r.f = (cpu._r.f & 0xEF) + co; cpu._r.m = 2; }

            public static void CPL() { cpu._r.a ^= 255; cpu._r.f = cpu._r.a != 0 ? 0 : 0x80; cpu._r.m = 1; }
            public static void NEG() { cpu._r.a = 0 - cpu._r.a; cpu._r.f = (cpu._r.a < 0) ? 0x10 : 0; cpu._r.a &= 255; if (cpu._r.a == 0) cpu._r.f |= 0x80; cpu._r.m = 2; }

            public static void CCF() { var ci = (cpu._r.f & 0x10) != 0 ? 0 : 0x10; cpu._r.f = (cpu._r.f & 0xEF) + ci; cpu._r.m = 1; }
            public static void SCF() { cpu._r.f |= 0x10; cpu._r.m = 1; }

            /*--- Stack ---*/
            public static void PUSHBC() { cpu._r.sp--; MMU.wb(cpu._r.sp, cpu._r.b); cpu._r.sp--; MMU.wb(cpu._r.sp, cpu._r.c); cpu._r.m = 3; }
            public static void PUSHDE() { cpu._r.sp--; MMU.wb(cpu._r.sp, cpu._r.d); cpu._r.sp--; MMU.wb(cpu._r.sp, cpu._r.e); cpu._r.m = 3; }
            public static void PUSHHL() { cpu._r.sp--; MMU.wb(cpu._r.sp, cpu._r.h); cpu._r.sp--; MMU.wb(cpu._r.sp, cpu._r.l); cpu._r.m = 3; }
            public static void PUSHAF() { cpu._r.sp--; MMU.wb(cpu._r.sp, cpu._r.a); cpu._r.sp--; MMU.wb(cpu._r.sp, cpu._r.f); cpu._r.m = 3; }

            public static void POPBC() { cpu._r.c = MMU.rb(cpu._r.sp); cpu._r.sp++; cpu._r.b = MMU.rb(cpu._r.sp); cpu._r.sp++; cpu._r.m = 3; }
            public static void POPDE() { cpu._r.e = MMU.rb(cpu._r.sp); cpu._r.sp++; cpu._r.d = MMU.rb(cpu._r.sp); cpu._r.sp++; cpu._r.m = 3; }
            public static void POPHL() { cpu._r.l = MMU.rb(cpu._r.sp); cpu._r.sp++; cpu._r.h = MMU.rb(cpu._r.sp); cpu._r.sp++; cpu._r.m = 3; }
            public static void POPAF() { cpu._r.f = MMU.rb(cpu._r.sp); cpu._r.sp++; cpu._r.a = MMU.rb(cpu._r.sp); cpu._r.sp++; cpu._r.m = 3; }

            /*--- Jump ---*/
            public static void JPnn() { cpu._r.pc = MMU.rw(cpu._r.pc); cpu._r.m = 3; }
            public static void JPHL() { cpu._r.pc = (cpu._r.h << 8) + cpu._r.l; cpu._r.m = 1; }
            public static void JPNZnn() { cpu._r.m = 3; if ((cpu._r.f & 0x80) == 0x00) { cpu._r.pc = MMU.rw(cpu._r.pc); cpu._r.m++; } else cpu._r.pc += 2; }
            public static void JPZnn() { cpu._r.m = 3; if ((cpu._r.f & 0x80) == 0x80) { cpu._r.pc = MMU.rw(cpu._r.pc); cpu._r.m++; } else cpu._r.pc += 2; }
            public static void JPNCnn() { cpu._r.m = 3; if ((cpu._r.f & 0x10) == 0x00) { cpu._r.pc = MMU.rw(cpu._r.pc); cpu._r.m++; } else cpu._r.pc += 2; }
            public static void JPCnn() { cpu._r.m = 3; if ((cpu._r.f & 0x10) == 0x10) { cpu._r.pc = MMU.rw(cpu._r.pc); cpu._r.m++; } else cpu._r.pc += 2; }

            public static void JRn() { var i = MMU.rb(cpu._r.pc); if (i > 127) i = -((~i + 1) & 255); cpu._r.pc++; cpu._r.m = 2; cpu._r.pc += i; cpu._r.m++; }
            public static void JRNZn() { var i = MMU.rb(cpu._r.pc); if (i > 127) i = -((~i + 1) & 255); cpu._r.pc++; cpu._r.m = 2; if ((cpu._r.f & 0x80) == 0x00) { cpu._r.pc += i; cpu._r.m++; } }
            public static void JRZn() { var i = MMU.rb(cpu._r.pc); if (i > 127) i = -((~i + 1) & 255); cpu._r.pc++; cpu._r.m = 2; if ((cpu._r.f & 0x80) == 0x80) { cpu._r.pc += i; cpu._r.m++; } }
            public static void JRNCn() { var i = MMU.rb(cpu._r.pc); if (i > 127) i = -((~i + 1) & 255); cpu._r.pc++; cpu._r.m = 2; if ((cpu._r.f & 0x10) == 0x00) { cpu._r.pc += i; cpu._r.m++; } }
            public static void JRCn() { var i = MMU.rb(cpu._r.pc); if (i > 127) i = -((~i + 1) & 255); cpu._r.pc++; cpu._r.m = 2; if ((cpu._r.f & 0x10) == 0x10) { cpu._r.pc += i; cpu._r.m++; } }

            public static void DJNZn() { var i = MMU.rb(cpu._r.pc); if (i > 127) i = -((~i + 1) & 255); cpu._r.pc++; cpu._r.m = 2; cpu._r.b--; if (cpu._r.b != 0) { cpu._r.pc += i; cpu._r.m++; } }

            public static void CALLnn() { cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc + 2); cpu._r.pc = MMU.rw(cpu._r.pc); cpu._r.m = 5; }
            public static void CALLNZnn() { cpu._r.m = 3; if ((cpu._r.f & 0x80) == 0x00) { cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc + 2); cpu._r.pc = MMU.rw(cpu._r.pc); cpu._r.m += 2; } else cpu._r.pc += 2; }
            public static void CALLZnn() { cpu._r.m = 3; if ((cpu._r.f & 0x80) == 0x80) { cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc + 2); cpu._r.pc = MMU.rw(cpu._r.pc); cpu._r.m += 2; } else cpu._r.pc += 2; }
            public static void CALLNCnn() { cpu._r.m = 3; if ((cpu._r.f & 0x10) == 0x00) { cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc + 2); cpu._r.pc = MMU.rw(cpu._r.pc); cpu._r.m += 2; } else cpu._r.pc += 2; }
            public static void CALLCnn() { cpu._r.m = 3; if ((cpu._r.f & 0x10) == 0x10) { cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc + 2); cpu._r.pc = MMU.rw(cpu._r.pc); cpu._r.m += 2; } else cpu._r.pc += 2; }

            public static void RET() { cpu._r.pc = MMU.rw(cpu._r.sp); cpu._r.sp += 2; cpu._r.m = 3; }
            public static void RETI() { cpu._r.ime = 1; cpu._ops.rrs(); cpu._r.pc = MMU.rw(cpu._r.sp); cpu._r.sp += 2; cpu._r.m = 3; }
            public static void RETNZ() { cpu._r.m = 1; if ((cpu._r.f & 0x80) == 0x00) { cpu._r.pc = MMU.rw(cpu._r.sp); cpu._r.sp += 2; cpu._r.m += 2; } }
            public static void RETZ() { cpu._r.m = 1; if ((cpu._r.f & 0x80) == 0x80) { cpu._r.pc = MMU.rw(cpu._r.sp); cpu._r.sp += 2; cpu._r.m += 2; } }
            public static void RETNC() { cpu._r.m = 1; if ((cpu._r.f & 0x10) == 0x00) { cpu._r.pc = MMU.rw(cpu._r.sp); cpu._r.sp += 2; cpu._r.m += 2; } }
            public static void RETC() { cpu._r.m = 1; if ((cpu._r.f & 0x10) == 0x10) { cpu._r.pc = MMU.rw(cpu._r.sp); cpu._r.sp += 2; cpu._r.m += 2; } }

            public static void RST00() { cpu._ops.rsv(); cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc); cpu._r.pc = 0x00; cpu._r.m = 3; }
            public static void RST08() { cpu._ops.rsv(); cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc); cpu._r.pc = 0x08; cpu._r.m = 3; }
            public static void RST10() { cpu._ops.rsv(); cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc); cpu._r.pc = 0x10; cpu._r.m = 3; }
            public static void RST18() { cpu._ops.rsv(); cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc); cpu._r.pc = 0x18; cpu._r.m = 3; }
            public static void RST20() { cpu._ops.rsv(); cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc); cpu._r.pc = 0x20; cpu._r.m = 3; }
            public static void RST28() { cpu._ops.rsv(); cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc); cpu._r.pc = 0x28; cpu._r.m = 3; }
            public static void RST30() { cpu._ops.rsv(); cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc); cpu._r.pc = 0x30; cpu._r.m = 3; }
            public static void RST38() { cpu._ops.rsv(); cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc); cpu._r.pc = 0x38; cpu._r.m = 3; }
            public static void RST40() { cpu._ops.rsv(); cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc); cpu._r.pc = 0x40; cpu._r.m = 3; }
            public static void RST48() { cpu._ops.rsv(); cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc); cpu._r.pc = 0x48; cpu._r.m = 3; }
            public static void RST50() { cpu._ops.rsv(); cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc); cpu._r.pc = 0x50; cpu._r.m = 3; }
            public static void RST58() { cpu._ops.rsv(); cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc); cpu._r.pc = 0x58; cpu._r.m = 3; }
            public static void RST60() { cpu._ops.rsv(); cpu._r.sp -= 2; MMU.ww(cpu._r.sp, cpu._r.pc); cpu._r.pc = 0x60; cpu._r.m = 3; }

            public static void NOP() { cpu._r.m = 1; }
            public static void HALT() { cpu._halt = 1; cpu._r.m = 1; }

            public static void DI() { cpu._r.ime = 0; cpu._r.m = 1; }
            public static void EI() { cpu._r.ime = 1; cpu._r.m = 1; }

            /*--- Helper functions ---*/
            public static void rsv()
            {
                cpu._rsv.a = cpu._r.a; cpu._rsv.b = cpu._r.b;
                cpu._rsv.c = cpu._r.c; cpu._rsv.d = cpu._r.d;
                cpu._rsv.e = cpu._r.e; cpu._rsv.f = cpu._r.f;
                cpu._rsv.h = cpu._r.h; cpu._rsv.l = cpu._r.l;
            }

            public static void rrs()
            {
                cpu._r.a = cpu._rsv.a; cpu._r.b = cpu._rsv.b;
                cpu._r.c = cpu._rsv.c; cpu._r.d = cpu._rsv.d;
                cpu._r.e = cpu._rsv.e; cpu._r.f = cpu._rsv.f;
                cpu._r.h = cpu._rsv.h; cpu._r.l = cpu._rsv.l;
            }

            public static void MAPcb()
            {
                var i = MMU.rb(cpu._r.pc); cpu._r.pc++;
                cpu._r.pc &= 65535;
                if (cpu._cbmap[i] != null) cpu._cbmap[i]();
                else Console.WriteLine(i);
            }

            public static void XX()
            {
                /*Undefined map entry*/
                var opc = cpu._r.pc - 1;
                LOG.@out("cpu", "Unimplemented instruction at $" + opc.ToString("XX") + ", stopping.");
                cpu._stop = 1;
            }
        }

        public static Action[] _map = new Action[] {
            // 00
            cpu._ops.NOP, cpu._ops.LDBCnn, cpu._ops.LDBCmA, cpu._ops.INCBC,
            cpu._ops.INCr_b, cpu._ops.DECr_b, cpu._ops.LDrn_b, cpu._ops.RLCA,
            /*cpu._ops.LDmmSP*/ _ops.XX, cpu._ops.ADDHLBC, cpu._ops.LDABCm, cpu._ops.DECBC,
            cpu._ops.INCr_c, cpu._ops.DECr_c, cpu._ops.LDrn_c, cpu._ops.RRCA,
            // 10
            cpu._ops.DJNZn, cpu._ops.LDDEnn, cpu._ops.LDDEmA, cpu._ops.INCDE,
            cpu._ops.INCr_d, cpu._ops.DECr_d, cpu._ops.LDrn_d, cpu._ops.RLA,
            cpu._ops.JRn, cpu._ops.ADDHLDE, cpu._ops.LDADEm, cpu._ops.DECDE,
            cpu._ops.INCr_e, cpu._ops.DECr_e, cpu._ops.LDrn_e, cpu._ops.RRA,
            // 20
            cpu._ops.JRNZn, cpu._ops.LDHLnn, cpu._ops.LDHLIA, cpu._ops.INCHL,
            cpu._ops.INCr_h, cpu._ops.DECr_h, cpu._ops.LDrn_h, cpu._ops.DAA,
            cpu._ops.JRZn, cpu._ops.ADDHLHL, cpu._ops.LDAHLI, cpu._ops.DECHL,
            cpu._ops.INCr_l, cpu._ops.DECr_l, cpu._ops.LDrn_l, cpu._ops.CPL,
            // 30
            cpu._ops.JRNCn, cpu._ops.LDSPnn, cpu._ops.LDHLDA, cpu._ops.INCSP,
            cpu._ops.INCHLm, cpu._ops.DECHLm, cpu._ops.LDHLmn, cpu._ops.SCF,
            cpu._ops.JRCn, cpu._ops.ADDHLSP, cpu._ops.LDAHLD, cpu._ops.DECSP,
            cpu._ops.INCr_a, cpu._ops.DECr_a, cpu._ops.LDrn_a, cpu._ops.CCF,
            // 40
            cpu._ops.LDrr_bb, cpu._ops.LDrr_bc, cpu._ops.LDrr_bd, cpu._ops.LDrr_be,
            cpu._ops.LDrr_bh, cpu._ops.LDrr_bl, cpu._ops.LDrHLm_b, cpu._ops.LDrr_ba,
            cpu._ops.LDrr_cb, cpu._ops.LDrr_cc, cpu._ops.LDrr_cd, cpu._ops.LDrr_ce,
            cpu._ops.LDrr_ch, cpu._ops.LDrr_cl, cpu._ops.LDrHLm_c, cpu._ops.LDrr_ca,
            // 50
            cpu._ops.LDrr_db, cpu._ops.LDrr_dc, cpu._ops.LDrr_dd, cpu._ops.LDrr_de,
            cpu._ops.LDrr_dh, cpu._ops.LDrr_dl, cpu._ops.LDrHLm_d, cpu._ops.LDrr_da,
            cpu._ops.LDrr_eb, cpu._ops.LDrr_ec, cpu._ops.LDrr_ed, cpu._ops.LDrr_ee,
            cpu._ops.LDrr_eh, cpu._ops.LDrr_el, cpu._ops.LDrHLm_e, cpu._ops.LDrr_ea,
            // 60
            cpu._ops.LDrr_hb, cpu._ops.LDrr_hc, cpu._ops.LDrr_hd, cpu._ops.LDrr_he,
            cpu._ops.LDrr_hh, cpu._ops.LDrr_hl, cpu._ops.LDrHLm_h, cpu._ops.LDrr_ha,
            cpu._ops.LDrr_lb, cpu._ops.LDrr_lc, cpu._ops.LDrr_ld, cpu._ops.LDrr_le,
            cpu._ops.LDrr_lh, cpu._ops.LDrr_ll, cpu._ops.LDrHLm_l, cpu._ops.LDrr_la,
            // 70
            cpu._ops.LDHLmr_b, cpu._ops.LDHLmr_c, cpu._ops.LDHLmr_d, cpu._ops.LDHLmr_e,
            cpu._ops.LDHLmr_h, cpu._ops.LDHLmr_l, cpu._ops.HALT, cpu._ops.LDHLmr_a,
            cpu._ops.LDrr_ab, cpu._ops.LDrr_ac, cpu._ops.LDrr_ad, cpu._ops.LDrr_ae,
            cpu._ops.LDrr_ah, cpu._ops.LDrr_al, cpu._ops.LDrHLm_a, cpu._ops.LDrr_aa,
            // 80
            cpu._ops.ADDr_b, cpu._ops.ADDr_c, cpu._ops.ADDr_d, cpu._ops.ADDr_e,
            cpu._ops.ADDr_h, cpu._ops.ADDr_l, cpu._ops.ADDHL, cpu._ops.ADDr_a,
            cpu._ops.ADCr_b, cpu._ops.ADCr_c, cpu._ops.ADCr_d, cpu._ops.ADCr_e,
            cpu._ops.ADCr_h, cpu._ops.ADCr_l, cpu._ops.ADCHL, cpu._ops.ADCr_a,
            // 90
            cpu._ops.SUBr_b, cpu._ops.SUBr_c, cpu._ops.SUBr_d, cpu._ops.SUBr_e,
            cpu._ops.SUBr_h, cpu._ops.SUBr_l, cpu._ops.SUBHL, cpu._ops.SUBr_a,
            cpu._ops.SBCr_b, cpu._ops.SBCr_c, cpu._ops.SBCr_d, cpu._ops.SBCr_e,
            cpu._ops.SBCr_h, cpu._ops.SBCr_l, cpu._ops.SBCHL, cpu._ops.SBCr_a,
            // A0
            cpu._ops.ANDr_b, cpu._ops.ANDr_c, cpu._ops.ANDr_d, cpu._ops.ANDr_e,
            cpu._ops.ANDr_h, cpu._ops.ANDr_l, cpu._ops.ANDHL, cpu._ops.ANDr_a,
            cpu._ops.XORr_b, cpu._ops.XORr_c, cpu._ops.XORr_d, cpu._ops.XORr_e,
            cpu._ops.XORr_h, cpu._ops.XORr_l, cpu._ops.XORHL, cpu._ops.XORr_a,
            // B0
            cpu._ops.ORr_b, cpu._ops.ORr_c, cpu._ops.ORr_d, cpu._ops.ORr_e,
            cpu._ops.ORr_h, cpu._ops.ORr_l, cpu._ops.ORHL, cpu._ops.ORr_a,
            cpu._ops.CPr_b, cpu._ops.CPr_c, cpu._ops.CPr_d, cpu._ops.CPr_e,
            cpu._ops.CPr_h, cpu._ops.CPr_l, cpu._ops.CPHL, cpu._ops.CPr_a,
            // C0
            cpu._ops.RETNZ, cpu._ops.POPBC, cpu._ops.JPNZnn, cpu._ops.JPnn,
            cpu._ops.CALLNZnn, cpu._ops.PUSHBC, cpu._ops.ADDn, cpu._ops.RST00,
            cpu._ops.RETZ, cpu._ops.RET, cpu._ops.JPZnn, cpu._ops.MAPcb,
            cpu._ops.CALLZnn, cpu._ops.CALLnn, cpu._ops.ADCn, cpu._ops.RST08,
            // D0
            cpu._ops.RETNC, cpu._ops.POPDE, cpu._ops.JPNCnn, cpu._ops.XX,
            cpu._ops.CALLNCnn, cpu._ops.PUSHDE, cpu._ops.SUBn, cpu._ops.RST10,
            cpu._ops.RETC, cpu._ops.RETI, cpu._ops.JPCnn, cpu._ops.XX,
            cpu._ops.CALLCnn, cpu._ops.XX, cpu._ops.SBCn, cpu._ops.RST18,
            // E0
            cpu._ops.LDIOnA, cpu._ops.POPHL, cpu._ops.LDIOCA, cpu._ops.XX,
            cpu._ops.XX, cpu._ops.PUSHHL, cpu._ops.ANDn, cpu._ops.RST20,
            cpu._ops.ADDSPn, cpu._ops.JPHL, cpu._ops.LDmmA, cpu._ops.XX,
            cpu._ops.XX, cpu._ops.XX, cpu._ops.XORn, cpu._ops.RST28,
            // F0
            cpu._ops.LDAIOn, cpu._ops.POPAF, cpu._ops.LDAIOC, cpu._ops.DI,
            cpu._ops.XX, cpu._ops.PUSHAF, cpu._ops.ORn, cpu._ops.RST30,
            cpu._ops.LDHLSPn, cpu._ops.XX, cpu._ops.LDAmm, cpu._ops.EI,
            cpu._ops.XX, cpu._ops.XX, cpu._ops.CPn, cpu._ops.RST38
        };

        public static Action[] _cbmap = new Action[]
        {
            // CB00
            cpu._ops.RLCr_b,  cpu._ops.RLCr_c,    cpu._ops.RLCr_d,    cpu._ops.RLCr_e,
            cpu._ops.RLCr_h,  cpu._ops.RLCr_l,    cpu._ops.RLCHL,     cpu._ops.RLCr_a,
            cpu._ops.RRCr_b,  cpu._ops.RRCr_c,    cpu._ops.RRCr_d,    cpu._ops.RRCr_e,
            cpu._ops.RRCr_h,  cpu._ops.RRCr_l,    cpu._ops.RRCHL,     cpu._ops.RRCr_a,
            // CB10
            cpu._ops.RLr_b,   cpu._ops.RLr_c,     cpu._ops.RLr_d,     cpu._ops.RLr_e,
            cpu._ops.RLr_h,   cpu._ops.RLr_l,     cpu._ops.RLHL,      cpu._ops.RLr_a,
            cpu._ops.RRr_b,   cpu._ops.RRr_c,     cpu._ops.RRr_d,     cpu._ops.RRr_e,
            cpu._ops.RRr_h,   cpu._ops.RRr_l,     cpu._ops.RRHL,      cpu._ops.RRr_a,
            // CB20
            cpu._ops.SLAr_b,  cpu._ops.SLAr_c,    cpu._ops.SLAr_d,    cpu._ops.SLAr_e,
            cpu._ops.SLAr_h,  cpu._ops.SLAr_l,    cpu._ops.XX,        cpu._ops.SLAr_a,
            cpu._ops.SRAr_b,  cpu._ops.SRAr_c,    cpu._ops.SRAr_d,    cpu._ops.SRAr_e,
            cpu._ops.SRAr_h,  cpu._ops.SRAr_l,    cpu._ops.XX,        cpu._ops.SRAr_a,
            // CB30
            cpu._ops.SWAPr_b, cpu._ops.SWAPr_c,   cpu._ops.SWAPr_d,   cpu._ops.SWAPr_e,
            cpu._ops.SWAPr_h, cpu._ops.SWAPr_l,   cpu._ops.XX,        cpu._ops.SWAPr_a,
            cpu._ops.SRLr_b,  cpu._ops.SRLr_c,    cpu._ops.SRLr_d,    cpu._ops.SRLr_e,
            cpu._ops.SRLr_h,  cpu._ops.SRLr_l,    cpu._ops.XX,        cpu._ops.SRLr_a,
            // CB40
            cpu._ops.BIT0b,   cpu._ops.BIT0c,     cpu._ops.BIT0d,     cpu._ops.BIT0e,
            cpu._ops.BIT0h,   cpu._ops.BIT0l,     cpu._ops.BIT0m,     cpu._ops.BIT0a,
            cpu._ops.BIT1b,   cpu._ops.BIT1c,     cpu._ops.BIT1d,     cpu._ops.BIT1e,
            cpu._ops.BIT1h,   cpu._ops.BIT1l,     cpu._ops.BIT1m,     cpu._ops.BIT1a,
            // CB50
            cpu._ops.BIT2b,   cpu._ops.BIT2c,     cpu._ops.BIT2d,     cpu._ops.BIT2e,
            cpu._ops.BIT2h,   cpu._ops.BIT2l,     cpu._ops.BIT2m,     cpu._ops.BIT2a,
            cpu._ops.BIT3b,   cpu._ops.BIT3c,     cpu._ops.BIT3d,     cpu._ops.BIT3e,
            cpu._ops.BIT3h,   cpu._ops.BIT3l,     cpu._ops.BIT3m,     cpu._ops.BIT3a,
            // CB60
            cpu._ops.BIT4b,   cpu._ops.BIT4c,     cpu._ops.BIT4d,     cpu._ops.BIT4e,
            cpu._ops.BIT4h,   cpu._ops.BIT4l,     cpu._ops.BIT4m,     cpu._ops.BIT4a,
            cpu._ops.BIT5b,   cpu._ops.BIT5c,     cpu._ops.BIT5d,     cpu._ops.BIT5e,
            cpu._ops.BIT5h,   cpu._ops.BIT5l,     cpu._ops.BIT5m,     cpu._ops.BIT5a,
            // CB70
            cpu._ops.BIT6b,   cpu._ops.BIT6c,     cpu._ops.BIT6d,     cpu._ops.BIT6e,
            cpu._ops.BIT6h,   cpu._ops.BIT6l,     cpu._ops.BIT6m,     cpu._ops.BIT6a,
            cpu._ops.BIT7b,   cpu._ops.BIT7c,     cpu._ops.BIT7d,     cpu._ops.BIT7e,
            cpu._ops.BIT7h,   cpu._ops.BIT7l,     cpu._ops.BIT7m,     cpu._ops.BIT7a,
            // CB80
            cpu._ops.RES0b,   cpu._ops.RES0c,     cpu._ops.RES0d,     cpu._ops.RES0e,
            cpu._ops.RES0h,   cpu._ops.RES0l,     cpu._ops.RES0m,     cpu._ops.RES0a,
            cpu._ops.RES1b,   cpu._ops.RES1c,     cpu._ops.RES1d,     cpu._ops.RES1e,
            cpu._ops.RES1h,   cpu._ops.RES1l,     cpu._ops.RES1m,     cpu._ops.RES1a,
            // CB90
            cpu._ops.RES2b,   cpu._ops.RES2c,     cpu._ops.RES2d,     cpu._ops.RES2e,
            cpu._ops.RES2h,   cpu._ops.RES2l,     cpu._ops.RES2m,     cpu._ops.RES2a,
            cpu._ops.RES3b,   cpu._ops.RES3c,     cpu._ops.RES3d,     cpu._ops.RES3e,
            cpu._ops.RES3h,   cpu._ops.RES3l,     cpu._ops.RES3m,     cpu._ops.RES3a,
            // CBA0
            cpu._ops.RES4b,   cpu._ops.RES4c,     cpu._ops.RES4d,     cpu._ops.RES4e,
            cpu._ops.RES4h,   cpu._ops.RES4l,     cpu._ops.RES4m,     cpu._ops.RES4a,
            cpu._ops.RES5b,   cpu._ops.RES5c,     cpu._ops.RES5d,     cpu._ops.RES5e,
            cpu._ops.RES5h,   cpu._ops.RES5l,     cpu._ops.RES5m,     cpu._ops.RES5a,
            // CBB0
            cpu._ops.RES6b,   cpu._ops.RES6c,     cpu._ops.RES6d,     cpu._ops.RES6e,
            cpu._ops.RES6h,   cpu._ops.RES6l,     cpu._ops.RES6m,     cpu._ops.RES6a,
            cpu._ops.RES7b,   cpu._ops.RES7c,     cpu._ops.RES7d,     cpu._ops.RES7e,
            cpu._ops.RES7h,   cpu._ops.RES7l,     cpu._ops.RES7m,     cpu._ops.RES7a,
            // CBC0
            cpu._ops.SET0b,   cpu._ops.SET0c,     cpu._ops.SET0d,     cpu._ops.SET0e,
            cpu._ops.SET0h,   cpu._ops.SET0l,     cpu._ops.SET0m,     cpu._ops.SET0a,
            cpu._ops.SET1b,   cpu._ops.SET1c,     cpu._ops.SET1d,     cpu._ops.SET1e,
            cpu._ops.SET1h,   cpu._ops.SET1l,     cpu._ops.SET1m,     cpu._ops.SET1a,
            // CBD0
            cpu._ops.SET2b,   cpu._ops.SET2c,     cpu._ops.SET2d,     cpu._ops.SET2e,
            cpu._ops.SET2h,   cpu._ops.SET2l,     cpu._ops.SET2m,     cpu._ops.SET2a,
            cpu._ops.SET3b,   cpu._ops.SET3c,     cpu._ops.SET3d,     cpu._ops.SET3e,
            cpu._ops.SET3h,   cpu._ops.SET3l,     cpu._ops.SET3m,     cpu._ops.SET3a,
            // CBE0
            cpu._ops.SET4b,   cpu._ops.SET4c,     cpu._ops.SET4d,     cpu._ops.SET4e,
            cpu._ops.SET4h,   cpu._ops.SET4l,     cpu._ops.SET4m,     cpu._ops.SET4a,
            cpu._ops.SET5b,   cpu._ops.SET5c,     cpu._ops.SET5d,     cpu._ops.SET5e,
            cpu._ops.SET5h,   cpu._ops.SET5l,     cpu._ops.SET5m,     cpu._ops.SET5a,
            // CBF0
            cpu._ops.SET6b,   cpu._ops.SET6c,     cpu._ops.SET6d,     cpu._ops.SET6e,
            cpu._ops.SET6h,   cpu._ops.SET6l,     cpu._ops.SET6m,     cpu._ops.SET6a,
            cpu._ops.SET7b,   cpu._ops.SET7c,     cpu._ops.SET7d,     cpu._ops.SET7e,
            cpu._ops.SET7h,   cpu._ops.SET7l,     cpu._ops.SET7m,     cpu._ops.SET7a,
        };
    }
}
